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
    public class InventoryService : BaseCRUDService<Model.Inventory, Database.Inventory, InventoryUpsertRequest, InventoryUpsertRequest, InventorySearchObject>
        , IInventoryService
    {
        public InventoryService(IMSContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IEnumerable<Model.Inventory> Get(InventorySearchObject search)
        {
            var list = _context.Inventories.AsQueryable();

            if (!string.IsNullOrEmpty(search?.Name))
                list = list.Where(x => x.Name.StartsWith(search.Name));
            if (search?.CityId != null)
                list = list.Where(x => x.Address.CityId == search.CityId);
            if (search?.SizeFrom != null && search?.SizeTo != null)
                list = list.Where(x => x.Size >= search.SizeFrom && x.Size <= search.SizeTo);

            return _mapper.Map<List<Model.Inventory>>(list.ToList());
        }

        public override Model.Inventory Insert(InventoryUpsertRequest request)
        {
            var entity = _mapper.Map<Database.Inventory>(request);

            Address address = new Address
            {
                Name = request.AddressName,
                CityId = request.CityId
            };
            _context.Addresses.Add(address);
            _context.SaveChanges();

            entity.AddressId = address.Id;
            _context.Inventories.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Inventory>(entity);
        }

        public override Model.Inventory Update(int id, InventoryUpsertRequest request)
        {
            var entity = _context.Inventories.Include(x => x.Address).FirstOrDefault(x => x.Id == id);

            _mapper.Map(request, entity);
            entity.Address.Name = request.AddressName;
            entity.Address.CityId = request.CityId;
            _context.SaveChanges();

            return _mapper.Map<Model.Inventory>(entity);
        }

    }
}
