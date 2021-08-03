using InventoryManagementSoftware.Database;
using InventoryManagementSoftware.Model.Requests;
using InventoryManagementSoftware.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSoftware.Controllers
{
    public class CountryController : BaseReadController<Model.Country, string>
    {
        public CountryController(ICountryService service) : base(service)
        {
        }
    }
}
