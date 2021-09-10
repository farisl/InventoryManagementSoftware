using InventoryManagementSoftware.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSoftware.Services
{
    public interface IProductService : ICRUDService<Model.Product, ProductUpsertRequest, ProductUpsertRequest, ProductSearchObject>
    {
        Model.Product Recommend(int id);
    }
}
