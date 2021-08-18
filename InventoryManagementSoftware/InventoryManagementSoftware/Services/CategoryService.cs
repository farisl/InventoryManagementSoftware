using AutoMapper;
using InventoryManagementSoftware.Database;
using InventoryManagementSoftware.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSoftware.Services
{
    public class CategoryService : BaseCRUDService<Model.Category, Database.Category, BaseUpsertRequest, BaseUpsertRequest, string>
        , ICategoryService
    {
        public CategoryService(IMSContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IEnumerable<Model.Category> Get(string search)
        {
            var list = _context.Categories.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
                list = list.Where(x => x.Name.StartsWith(search));

            return _mapper.Map<List<Model.Category>>(list.ToList());
        }

    }
}
