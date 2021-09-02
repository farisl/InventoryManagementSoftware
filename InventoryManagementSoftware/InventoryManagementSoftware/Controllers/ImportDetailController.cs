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
    public class ImportDetailController : BaseCRUDController<Model.ImportDetail, Database.ImportDetail, ImportDetailInsertRequest, ImportDetailUpdateRequest, ImportExportDetailSearchObject>
    {
        private readonly IImportDetailService _service;

        public ImportDetailController(IImportDetailService service) : base(service)
        {
            _service = service;
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _service.Delete(id);
        }
    }
}
