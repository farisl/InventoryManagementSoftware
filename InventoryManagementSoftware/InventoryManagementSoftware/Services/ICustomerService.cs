using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagementSoftware.Model.Requests;

namespace InventoryManagementSoftware.Services
{
    public interface ICustomerService : ICRUDService<Model.Customer, CustomerUpsertRequest, CustomerUpsertRequest, CustomerSearchObject>
    {
    }
}
