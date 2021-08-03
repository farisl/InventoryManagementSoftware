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
    public class CustomerController : BaseCRUDController<Model.Customer, Database.Customer, CustomerUpsertRequest, CustomerUpsertRequest, CustomerSearchObject>
    {
        public CustomerController(ICustomerService service) : base(service)
        {
        }
    }
}
