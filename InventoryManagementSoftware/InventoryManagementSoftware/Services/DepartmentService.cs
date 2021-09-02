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

            if (search?.EmployeeId != null)
                list = list.Where(x => EmployeeDepartmentsIds((int)search.EmployeeId).Contains(x.Id));

            return _mapper.Map<List<Model.Department>>(list.ToList());
        }

        private List<int> EmployeeDepartmentsIds(int employeeId)
        {
            int? inventoryId = _context.EmployeeInventories.Where(x => x.EmployeeId == employeeId && x.EndDate == null)
                .FirstOrDefault()?.InventoryId;

            if (inventoryId == null)
                return null;

            List<int> list = _context.Departments.Where(x => x.InventoryId == inventoryId).Select(x => x.Id).ToList();

            return list;
        }


    }
}
