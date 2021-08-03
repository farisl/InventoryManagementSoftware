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
    public class SupplierController : BaseCRUDController<Model.Supplier, Database.Supplier, SupplierUpsertRequest, SupplierUpsertRequest, SupplierSearchObject>
    {
        public SupplierController(ISupplierService service) : base(service)
        {
        }
    }
}
