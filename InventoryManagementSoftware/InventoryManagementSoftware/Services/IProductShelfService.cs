using InventoryManagementSoftware.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSoftware.Services
{
    public interface IProductShelfService : ICRUDService<Model.ProductShelf, ProductShelfUpsertRequest, ProductShelfUpsertRequest, ProductShelfSearchObject>
    {
        IEnumerable<Model.ProductShelf> Delete(int id);
    }
}
