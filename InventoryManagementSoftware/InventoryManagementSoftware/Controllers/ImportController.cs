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
    public class ImportController : BaseCRUDController<Model.Import, Database.Import, ImportInsertRequest, ImportUpdateRequest, ImportSearchObject>
    {
        public ImportController(IImportService service) : base(service)
        {
        }
    }
}
