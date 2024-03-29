﻿using InventoryManagementSoftware.Model;
using InventoryManagementSoftware.Model.Requests;
using InventoryManagementSoftware.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSoftware.Controllers
{
    public class BrandController : BaseCRUDController<Model.Brand, Database.Brand, BrandUpsertRequest, BrandUpsertRequest, BrandSearchObject>
    {
        public BrandController(IBrandService service) : base(service)
        {
        }
    }
}
