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
    public class ImportDetailController : BaseCRUDController<Model.ImportDetail, Database.ImportDetail, ImportDetailInsertRequest, ImportDetailUpdateRequest, object>
    {
        private readonly IImportDetailService _service;

        public ImportDetailController(IImportDetailService service) : base(service)
        {
        }

        [HttpDelete("{id}")]
        public IEnumerable<Model.ImportDetail> Delete(int id)
        {
            return _service.Delete(id);
        }
    }
}
