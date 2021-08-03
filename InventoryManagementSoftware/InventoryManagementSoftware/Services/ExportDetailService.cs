using AutoMapper;
using InventoryManagementSoftware.Database;
using InventoryManagementSoftware.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSoftware.Services
{
    public class ExportDetailService : BaseCRUDService<Model.ExportDetail, Database.ExportDetail, ExportDetailInsertRequest, ExportDetailUpdateRequest, object>
        , IExportDetailService
    {
        public ExportDetailService(IMSContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override Model.ExportDetail Insert(ExportDetailInsertRequest request)
        {
            var entity = _mapper.Map<Database.ExportDetail>(request);

            var productPrice = _context.ProductPrices.Where(x => x.ProductId == request.ProductId && x.EndDate == null).FirstOrDefault();
            entity.Price = productPrice == null ? 0
                : (productPrice.Price * request.Quantity) - (productPrice.Price * request.Quantity * request.Discount);
            _context.ExportDetails.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.ExportDetail>(entity);
        }

        public override Model.ExportDetail Update(int id, ExportDetailUpdateRequest request)
        {
            var entity = _context.ExportDetails.Find(id);

            _mapper.Map(request, entity);
            var productPrice = _context.ProductPrices.Where(x => x.ProductId == request.ProductId && x.EndDate == null).FirstOrDefault();
            entity.Price = productPrice == null ? 0
                : (productPrice.Price * request.Quantity) - (productPrice.Price * request.Quantity * request.Discount);
            _context.SaveChanges();

            return _mapper.Map<Model.ExportDetail>(entity);
        }

        public IEnumerable<Model.ExportDetail> Delete(int id)
        {
            var entity = _context.ExportDetails.Find(id);

            _context.ExportDetails.Remove(entity);
            _context.SaveChanges();

            var list = _context.ExportDetails.ToList();
            return _mapper.Map<List<Model.ExportDetail>>(list);
        }
    }
}
