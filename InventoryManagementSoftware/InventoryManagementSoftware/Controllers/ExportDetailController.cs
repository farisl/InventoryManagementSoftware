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
    public class ExportDetailController : BaseCRUDController<Model.ExportDetail, Database.ExportDetail, ExportDetailInsertRequest, ExportDetailUpdateRequest, object>
    {
        private readonly IExportDetailService _service;

        public ExportDetailController(IExportDetailService service) : base(service)
        {
            _service = service;
        }

        [HttpDelete("{id}")]
        public IEnumerable<Model.ExportDetail> Delete(int id)
        {
            return _service.Delete(id);
        }

    }
}
