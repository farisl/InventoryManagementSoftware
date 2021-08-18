using InventoryManagementSoftware.Model;
using InventoryManagementSoftware.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSoftware.Controllers
{
    public class GenderController : BaseReadController<Model.Gender, object>
    {
        public GenderController(IGenderService service) : base(service)
        {
        }
    }
}
