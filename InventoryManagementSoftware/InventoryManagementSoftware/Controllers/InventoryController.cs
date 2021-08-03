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
    public class InventoryController : BaseCRUDController<Model.Inventory, Database.Inventory, InventoryUpsertRequest, InventoryUpsertRequest, InventorySearchObject>
    {
        public InventoryController(IInventoryService service) : base(service)
        {
        }
    }
}
