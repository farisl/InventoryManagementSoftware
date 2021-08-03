using AutoMapper;
using InventoryManagementSoftware.Database;
using InventoryManagementSoftware.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSoftware.Services
{
    public class ProductService : BaseCRUDService<Model.Product, Database.Product, ProductUpsertRequest, ProductUpsertRequest, ProductSearchObject>
        , IProductService
    {
        public ProductService(IMSContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IEnumerable<Model.Product> Get(ProductSearchObject search)
        {
            var list = _context.Products.AsQueryable().Where(x => !x.IsDeleted);

            if (search?.Name != null)
                list = list.Where(x => x.Name.StartsWith(search.Name));
            if(search?.CategoryId != null)
            {
                var productIds = _context.Products.Where(x => x.CategoryBrand.CategoryId == search.CategoryId)
                    .Select(x => x.Id).ToList();
                if (productIds.Count == 0)
                    return new List<Model.Product>();
                list = list.Where(x => productIds.Contains(x.Id));
            }
            if (search?.BrandId != null)
            {
                var productIds = _context.Products.Where(x => x.CategoryBrand.BrandId == search.BrandId)
                    .Select(x => x.Id).ToList();
                if (productIds?.Count == 0)
                    return new List<Model.Product>();
                list = list.Where(x => productIds.Contains(x.Id));
            }
            if(search?.PriceFrom != null && search?.PriceTo != null)
            {
                var productIds = _context.ProductPrices.Where(x => x.Price >= search.PriceFrom && x.Price <= search.PriceTo)
                    .Select(x => x.ProductId).ToList();
                if (productIds?.Count == 0)
                    return new List<Model.Product>();
                list = list.Where(x => productIds.Contains(x.Id));
            }

            return _mapper.Map<List<Model.Product>>(list.ToList());
        }

        public override Model.Product Insert(ProductUpsertRequest request)
        {
            var entity = _mapper.Map<Database.Product>(request);

            entity.CategoryBrandId = _context.CategoriesBrands.Where(x => x.CategoryId == request.CategoryId && x.BrandId == request.BrandId)
                .Select(x => x.Id).FirstOrDefault();
            entity.IsDeleted = false;
            _context.Products.Add(entity);
            _context.SaveChanges();

            if(request.Price != null)
            {
                _context.ProductPrices.Add(new ProductPrice
                {
                    Price = (double)request.Price,
                    ProductId = entity.Id,
                    StartDate = DateTime.Now,
                    EndDate = null,
                    IsDeleted = false
                });
                _context.SaveChanges();
            }

            foreach(var item in request.ProductAttributes)
            {
                Database.Attribute attribute = new Database.Attribute { Name = item.AttributeName };
                _context.Attributes.Add(attribute);
                _context.SaveChanges();

                _context.ProductAttributes.Add(new ProductAttribute
                {
                    AttributeId = attribute.Id,
                    ProductId = entity.Id,
                    Value = item.AttributeValue
                });
                _context.SaveChanges();
            }

            return _mapper.Map<Model.Product>(entity);
        }

        public override Model.Product Update(int id, ProductUpsertRequest request)
        {
            var entity = _context.Products.Find(id);

            _mapper.Map(request, entity);

            entity.CategoryBrandId = _context.CategoriesBrands.Where(x => x.CategoryId == request.CategoryId && x.BrandId == request.BrandId)
                .Select(x => x.Id).FirstOrDefault();

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

    }
}
