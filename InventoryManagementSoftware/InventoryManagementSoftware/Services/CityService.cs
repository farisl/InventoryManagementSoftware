using AutoMapper;
using InventoryManagementSoftware.Database;
using InventoryManagementSoftware.Model;
using InventoryManagementSoftware.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSoftware.Services
{
    public class CityService : BaseCRUDService<Model.City, Database.City, CityUpsertRequest, CityUpsertRequest, CitySearchObject>, ICityService
    {
        public CityService(IMSContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IEnumerable<Model.City> Get(CitySearchObject search = null)
        {
            var list = _context.Cities.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Name))
                list = list.Where(x => x.Name.StartsWith(search.Name));
            if (search?.CountryId != null)
                list = list.Where(x => x.CountryId == search.CountryId);

            return _mapper.Map<List<Model.City>>(list.ToList());
        }
    }
}
