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
    public class DepartmentController : BaseCRUDController<Model.Department, Database.Department, DepartmentUpsertRequest, DepartmentUpsertRequest, DepartmentSearchObject>
    {
        public DepartmentController(IDepartmentService service) : base(service)
        {
        }
    }
}
