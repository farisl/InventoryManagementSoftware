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
    public class ProductAttributeController : BaseCRUDController<Model.ProductAttribute, Database.ProductAttribute, ProductAttributeUpsertRequest, ProductAttributeUpsertRequest, ProductAttributeSearchObject>
    {
        private readonly IProductAttributeService _service;

        public ProductAttributeController(IProductAttributeService service) : base(service)
        {
            _service = service;
        }

        [HttpDelete("{id}")]
        public IEnumerable<Model.ProductAttribute> Delete(int id)
        {
            return _service.Delete(id);
        }

    }
}
