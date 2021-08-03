using InventoryManagementSoftware.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSoftware.Services
{
    public interface IExportDetailService : ICRUDService<Model.ExportDetail, ExportDetailInsertRequest, ExportDetailUpdateRequest, object>
    {
        IEnumerable<Model.ExportDetail> Delete(int id);
    }
}
