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
    public class ProductShelfController : BaseCRUDController<Model.ProductShelf, Database.ProductShelf, ProductShelfUpsertRequest, ProductShelfUpsertRequest, ProductShelfSearchObject>
    {
        private readonly IProductShelfService _service;

        public ProductShelfController(IProductShelfService service) : base(service)
        {
            _service = service;
        }

        [HttpDelete("{id}")]
        public IEnumerable<Model.ProductShelf> Delete(int id)
        {
            return _service.Delete(id);
        }

    }
}
