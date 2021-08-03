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
    public class CustomerService : BaseCRUDService<Model.Customer, Database.Customer, CustomerUpsertRequest, CustomerUpsertRequest, CustomerSearchObject>
        , ICustomerService
    {
        public CustomerService(IMSContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IEnumerable<Model.Customer> Get(CustomerSearchObject search)
        {
            var list = _context.Customers.AsQueryable();

            if (!string.IsNullOrEmpty(search?.Name))
                list = list.Where(x => x.Name.StartsWith(search.Name));
            if (search?.CityId != null)
                list = list.Where(x => x.Address.CityId == search.CityId);

            return _mapper.Map<List<Model.Customer>>(list.ToList());
        }

        public override Model.Customer Insert(CustomerUpsertRequest request)
        {
            var entity = _mapper.Map<Database.Customer>(request);

            Address address = new Address
            {
                Name = request.AddressName,
                CityId = request.CityId
            };
            _context.Addresses.Add(address);
            _context.SaveChanges();

            entity.AddressId = address.Id;
            _context.Customers.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Customer>(entity);
        }

        public override Model.Customer Update(int id, CustomerUpsertRequest request)
        {
            var entity = _context.Customers.Include(x => x.Address).FirstOrDefault(x => x.Id == id);

            _mapper.Map(request, entity);
            entity.Address.Name = request.AddressName;
            entity.Address.CityId = request.CityId;
            _context.SaveChanges();

            return _mapper.Map<Model.Customer>(entity);
        }

    }
}
