using AutoMapper;
using eProdaja.Filters;
using InventoryManagementSoftware.Database;
using InventoryManagementSoftware.ML;
using InventoryManagementSoftware.Model.Requests;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Microsoft.ML.Trainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSoftware.Services
{
    public class ProductService : BaseCRUDService<Model.Product, Database.Product, ProductUpsertRequest, ProductUpsertRequest, ProductSearchObject>
        , IProductService
    {
        static MLContext mlContext = null;
        static ITransformer model = null;

        public ProductService(IMSContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IEnumerable<Model.Product> Get(ProductSearchObject search)
        {
            var list = _context.Products.Include(x => x.CategoryBrand).ThenInclude(x => x.Category)
                .AsQueryable().Where(x => !x.IsDeleted);

            if (search?.Name != null)
                list = list.Where(x => x.Name.StartsWith(search.Name));
            if(search?.CategoryId != null)
            {
                list = list.Where(x => x.CategoryBrand.CategoryId == search.CategoryId);
            }
            if (search?.BrandId != null)
            {
                list = list.Where(x => x.CategoryBrand.BrandId == search.BrandId);
            }
            if(search?.PriceFrom != null && search?.PriceTo != null)
            {
                var productIds = _context.ProductPrices.Where(x => x.Price >= search.PriceFrom && x.Price <= search.PriceTo)
                    .Select(x => x.ProductId).ToList();
                if (productIds?.Count == 0)
                    return new List<Model.Product>();
                list = list.Where(x => productIds.Contains(x.Id));
            }

            if (search?.EmployeeId != null)
                list = list.Where(x => EmployeeProductsIds((int)search.EmployeeId).Contains(x.Id));
            if (search?.DepartmentId != null)
                list = list.Where(x => DepartmentProductsIds((int)search.DepartmentId).Contains(x.Id));


            var result = _mapper.Map<List<Model.Product>>(list.ToList());
            var productPrices = _context.ProductPrices.Where(x => x.EndDate == null).ToList();
            foreach(var item in result)
            {
                item.PriceValue = productPrices.Where(x => x.ProductId == item.Id).First().Price;
                var product = _context.Products.Include(x => x.CategoryBrand).ThenInclude(x => x.Brand).First(x => x.Id == item.Id);
                item.Brand = product.CategoryBrand.Brand.Name;
            }

            return result;
        }

        public override Model.Product Insert(ProductUpsertRequest request)
        {
            var entity = _mapper.Map<Database.Product>(request);

            entity.CategoryBrandId = _context.CategoriesBrands
                .Include(x => x.Category)
                .Where(x => x.CategoryId == request.CategoryId && x.BrandId == request.BrandId)
                .Select(x => x.Id).FirstOrDefault();
            entity.IsDeleted = false;
            _context.Products.Add(entity);
            _context.SaveChanges();

            _context.ProductPrices.Add(new ProductPrice
            {
                Price = request.Price,
                ProductId = entity.Id,
                StartDate = DateTime.Now,
                EndDate = null,
                IsDeleted = false
            });
            _context.SaveChanges();

            return _mapper.Map<Model.Product>(entity);
        }

        public override Model.Product Update(int id, ProductUpsertRequest request)
        {
            var entity = _context.Products.Find(id);

            _mapper.Map(request, entity);
            _context.SaveChanges();

            entity.CategoryBrandId = _context.CategoriesBrands.Where(x => x.CategoryId == request.CategoryId && x.BrandId == request.BrandId)
                .Select(x => x.Id).FirstOrDefault();
            _context.SaveChanges();

            var productPrice = _context.ProductPrices.Where(x => x.ProductId == id && x.EndDate == null).FirstOrDefault();
            if(productPrice.Price != request.Price)
            {
                productPrice.EndDate = DateTime.Now;
                _context.ProductPrices.Add(new ProductPrice
                {
                    Price = (double)request.Price,
                    ProductId = id,
                    IsDeleted = false,
                    StartDate = DateTime.Now,
                    EndDate = null
                });
                _context.SaveChanges();
            }

            return _mapper.Map<Model.Product>(entity);
        }

        private List<int> EmployeeProductsIds(int employeeId)
        {
            int? inventoryId = _context.EmployeeInventories.Where(x => x.EmployeeId == employeeId && x.EndDate == null)
                .FirstOrDefault()?.InventoryId;

            if (inventoryId == null)
                return new List<int>();

            List<int> list = _context.ProductShelves.Where(x => x.Shelf.Department.InventoryId == inventoryId)
                .Select(x => x.ProductId).ToList();

            return list;
        }

        private List<int> DepartmentProductsIds(int departmendId)
        {
            return _context.ProductShelves.Where(x => x.Shelf.DepartmentId == departmendId)
                .Select(x => x.ProductId).ToList();
        }

        public Model.Product Recommend(int id)
        {
            if(mlContext == null)
            {
                //STEP 1: Create MLContext to be shared across the model creation workflow objects
                mlContext = new MLContext();              
            }

            //STEP 2: Read the trained data using TextLoader by defining the schema for reading the product co-purchase dataset
            //        Do remember to replace amazon0302.txt with dataset from https://snap.stanford.edu/data/amazon0302.html

            var tmpData = _context.Exports.Include(x => x.ExportDetails).ToList();

            var data = new List<ProductEntry>();
            foreach (var x in tmpData)
            {
                if (x.ExportDetails.Count > 1)
                {
                    var distinctItemId = x.ExportDetails.Select(y => y.ProductId).ToList();
                    distinctItemId.ForEach(y =>
                    {
                        var relatedItems = x.ExportDetails.Where(z => z.ProductId != y).ToList();

                        relatedItems.ForEach(z =>
                        {
                            data.Add(new ProductEntry
                            {
                                ProductID = (uint)y,
                                CoPurchaseProductID = (uint)z.ProductId
                            });
                        });
                    });
                }
            }

            var traindata = mlContext.Data.LoadFromEnumerable(data);

            //STEP 3: Your data is already encoded so all you need to do is specify options for MatrxiFactorizationTrainer with a few extra hyperparameters
            //        LossFunction, Alpa, Lambda and a few others like K and C as shown below and call the trainer.
            MatrixFactorizationTrainer.Options options = new MatrixFactorizationTrainer.Options();
            options.MatrixColumnIndexColumnName = nameof(ProductEntry.ProductID);
            options.MatrixRowIndexColumnName = nameof(ProductEntry.CoPurchaseProductID);
            options.LabelColumnName = "Label";
            options.LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossOneClass;
            options.Alpha = 0.01;
            options.Lambda = 0.025;
            // For better results use the following parameters
            //options.K = 100;
            options.C = 0.00001;

            //Step 4: Call the MatrixFactorization trainer by passing options.
            var est = mlContext.Recommendation().Trainers.MatrixFactorization(options);

            //STEP 5: Train the model fitting to the DataSet
            //Please add Amazon0302.txt dataset from https://snap.stanford.edu/data/amazon0302.html to Data folder if FileNotFoundException is thrown.
            model = est.Fit(traindata);

            //STEP 6: Create prediction engine and predict the score for Product 63 being co-purchased with Product 3.
            //        The higher the score the higher the probability for this particular productID being co-purchased
            var allItems = _context.Products.Where(x => x.Id != id).ToList();

            var predictionResult = new List<Tuple<Database.Product, float>>();

            foreach(var item in allItems)
            {
                var predictionengine = mlContext.Model
                    .CreatePredictionEngine<ProductEntry, Copurchase_prediction>(model);
                var prediction = predictionengine.Predict(
                                         new ProductEntry()
                                         {
                                             ProductID = (uint)id,
                                             CoPurchaseProductID = (uint)item.Id
                                         });
                predictionResult.Add(new Tuple<Product, float>(item, prediction.Score));
            }

            var finalResult = predictionResult.OrderByDescending(x => x.Item2)
                .Select(x => x.Item1).FirstOrDefault();

            return _mapper.Map<Model.Product>(finalResult);
        }
    }
}
