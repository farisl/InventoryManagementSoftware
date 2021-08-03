using InventoryManagementSoftware.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSoftware.Services
{
    public interface IExportService : ICRUDService<Model.Export, ExportInsertRequest, ExportUpdateRequest, ExportSearchObject>
    {
    }
}
