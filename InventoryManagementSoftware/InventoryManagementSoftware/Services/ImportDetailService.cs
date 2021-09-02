using AutoMapper;
using eProdaja.Filters;
using InventoryManagementSoftware.Database;
using InventoryManagementSoftware.Model.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSoftware.Services
{
    public class ImportDetailService : BaseCRUDService<Model.ImportDetail, Database.ImportDetail, ImportDetailInsertRequest, ImportDetailUpdateRequest, ImportExportDetailSearchObject>
        , IImportDetailService
    {
        public ImportDetailService(IMSContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IEnumerable<Model.ImportDetail> Get(ImportExportDetailSearchObject search)
        {
            var list = _context.ImportDetails.Include(x => x.Product).AsQueryable();

            if (search?.ImportExportId != null)
                list = list.Where(x => x.ImportId == search.ImportExportId);

            return _mapper.Map<List<Model.ImportDetail>>(list);
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

        public bool Delete(int id)
        {
            var entity = _context.ImportDetails.Find(id);

            if (entity == null)
                throw new UserException("Entity with provided id does not exist!");

            _context.ImportDetails.Remove(entity);
            _context.SaveChanges();

            return true;
        }
    }
}
