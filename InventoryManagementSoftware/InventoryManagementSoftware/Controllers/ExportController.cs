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
    public class ExportController : BaseCRUDController<Model.Export, Database.Export, ExportInsertRequest, ExportUpdateRequest, ExportSearchObject>
    {
        public ExportController(IExportService service) : base(service)
        {
        }
    }
}
