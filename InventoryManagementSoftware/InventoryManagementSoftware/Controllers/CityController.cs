using InventoryManagementSoftware.Model.Requests;
using InventoryManagementSoftware.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSoftware.Controllers
{
    public class CityController : BaseCRUDController<Model.City, Database.City, CityUpsertRequest, CityUpsertRequest, CityUpsertRequest>
    {

        public CityController(ICityService service) : base(service)
        {
        }

    }
}
