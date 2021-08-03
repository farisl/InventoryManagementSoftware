using AutoMapper;
using InventoryManagementSoftware.Database;
using InventoryManagementSoftware.Model.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSoftware.Services
{
    public class SupplierService : BaseCRUDService<Model.Supplier, Database.Supplier, SupplierUpsertRequest, SupplierUpsertRequest, SupplierSearchObject>
        , ISupplierService
    {
        public SupplierService(IMSContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IEnumerable<Model.Supplier> Get(SupplierSearchObject search)
        {
            var list = _context.Suppliers.AsQueryable();

            if (!string.IsNullOrEmpty(search?.Name))
                list = list.Where(x => x.Name.StartsWith(search.Name));
            if (search?.CityId != null)
                list = list.Where(x => x.Address.CityId == search.CityId);

            return _mapper.Map<List<Model.Supplier>>(list.ToList());
        }

        public override Model.Supplier Insert(SupplierUpsertRequest request)
        {
            var entity = _mapper.Map<Database.Supplier>(request);

            Address address = new Address
            {
                Name = request.AddressName,
                CityId = request.CityId
            };
            _context.Addresses.Add(address);
            _context.SaveChanges();

            entity.AddressId = address.Id;
            _context.Suppliers.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Supplier>(entity);
        }

        public override Model.Supplier Update(int id, SupplierUpsertRequest request)
        {
            var entity = _context.Suppliers.Include(x => x.Address).FirstOrDefault(x => x.Id == id);

            _mapper.Map(request, entity);
            entity.Address.Name = request.AddressName;
            entity.Address.CityId = request.CityId;
            _context.SaveChanges();

            return _mapper.Map<Model.Supplier>(entity);
        }
    }
}
