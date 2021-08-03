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
    public class ShelfController : BaseCRUDController<Model.Shelf, Database.Shelf, ShelfInsertRequest, ShelfUpdateRequest, ShelfSearchObject>
    {
        public ShelfController(IShelfService service) : base(service)
        {
        }
    }
}
