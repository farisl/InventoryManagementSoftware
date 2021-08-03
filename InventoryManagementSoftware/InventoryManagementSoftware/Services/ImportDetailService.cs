using AutoMapper;
using InventoryManagementSoftware.Database;
using InventoryManagementSoftware.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSoftware.Services
{
    public class ImportDetailService : BaseCRUDService<Model.ImportDetail, Database.ImportDetail, ImportDetailInsertRequest, ImportDetailUpdateRequest, object>
        , IImportDetailService
    {
        public ImportDetailService(IMSContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override Model.ImportDetail Insert(ImportDetailInsertRequest request)
        {
            var entity = _mapper.Map<Database.ImportDetail>(request);

            var productPrice = _context.ProductPrices.Where(x => x.ProductId == request.ProductId && x.EndDate == null).FirstOrDefault();
            entity.Price = productPrice == null ? 0
                : (productPrice.Price * request.Quantity) - (productPrice.Price * request.Quantity * request.Discount);
            _context.ImportDetails.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.ImportDetail>(entity);
        }

        public override Model.ImportDetail Update(int id, ImportDetailUpdateRequest request)
        {
            var entity = _context.ImportDetails.Find(id);

            _mapper.Map(request, entity);
            var productPrice = _context.ProductPrices.Where(x => x.ProductId == request.ProductId && x.EndDate == null).FirstOrDefault();
            entity.Price = productPrice == null ? 0
                : (productPrice.Price * request.Quantity) - (productPrice.Price * request.Quantity * request.Discount);
            _context.SaveChanges();

            return _mapper.Map<Model.ImportDetail>(entity);
        }

        public IEnumerable<Model.ImportDetail> Delete(int id)
        {
            var entity = _context.ImportDetails.Find(id);

            _context.ImportDetails.Remove(entity);
            _context.SaveChanges();

            var list = _context.ImportDetails.ToList();
            return _mapper.Map<List<Model.ImportDetail>>(list);
        }
    }
}
