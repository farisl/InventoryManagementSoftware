using AutoMapper;
using InventoryManagementSoftware.Database;
using InventoryManagementSoftware.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSoftware.Services
{
    public class CountryService : BaseReadService<Model.Country, Database.Country, string>, ICountryService
    {
        public CountryService(IMSContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IEnumerable<Model.Country> Get(string search)
        {
            var list = _context.Countries.AsQueryable();

            if (search != null && !string.IsNullOrEmpty(search))
                list = list.Where(x => x.Name.StartsWith(search));

            return _mapper.Map<List<Model.Country>>(list.ToList());
        }

    }
}
