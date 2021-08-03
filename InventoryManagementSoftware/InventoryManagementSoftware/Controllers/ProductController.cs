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
    public class ProductController : BaseCRUDController<Model.Product, Database.Product, ProductUpsertRequest, ProductUpsertRequest, ProductSearchObject>
    {
        public ProductController(IProductService service) : base(service)
        {
        }
    }
}
