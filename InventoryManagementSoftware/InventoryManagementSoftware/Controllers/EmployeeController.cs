using InventoryManagementSoftware.Model;
using InventoryManagementSoftware.Model.Requests;
using InventoryManagementSoftware.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSoftware.Controllers
{
    public class EmployeeController : BaseCRUDController<Model.Employee, Database.Employee, EmployeeInsertRequest, EmployeeUpdateRequest, EmployeeSearchObject>
    {
        public EmployeeController(IEmployeeService service) : base(service)
        {
        }
    }
}
