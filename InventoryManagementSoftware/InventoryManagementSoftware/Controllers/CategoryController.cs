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
    public class CategoryController : BaseCRUDController<Model.Category, Database.Category, BaseUpsertRequest, BaseUpsertRequest, BaseUpsertRequest>
    {
        public CategoryController(ICategoryService service) : base(service)
        {
        }
    }
}
