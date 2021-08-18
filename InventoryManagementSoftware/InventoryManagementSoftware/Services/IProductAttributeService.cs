using InventoryManagementSoftware.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSoftware.Services
{
    public interface IProductAttributeService : ICRUDService<Model.ProductAttribute, ProductAttributeUpsertRequest, ProductAttributeUpsertRequest, ProductAttributeSearchObject>
    {
        IEnumerable<Model.ProductAttribute> Delete(int id);
    }
}
