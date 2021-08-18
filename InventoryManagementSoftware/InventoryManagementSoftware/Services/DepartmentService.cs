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
    public class DepartmentService : BaseCRUDService<Model.Department, Database.Department, DepartmentUpsertRequest, DepartmentUpsertRequest, DepartmentSearchObject>
        , IDepartmentService
    {
        public DepartmentService(IMSContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IEnumerable<Model.Department> Get(DepartmentSearchObject search)
        {
            var list = _context.Departments
                .Include(x => x.Inventory)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search?.Name))
                list = list.Where(x => x.Name.StartsWith(search.Name));
            if (search?.InventoryId != null)
                list = list.Where(x => x.InventoryId == search.InventoryId);
            if (search?.SizeFrom != null && search?.SizeTo != null)
                list = list.Where(x => x.Size >= search.SizeFrom && x.Size <= search.SizeTo);

            return _mapper.Map<List<Model.Department>>(list.ToList());
        }

    }
}
