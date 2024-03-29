﻿using InventoryManagementSoftware.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSoftware.Services
{
    public interface IImportDetailService : ICRUDService<Model.ImportDetail, ImportDetailInsertRequest, ImportDetailUpdateRequest, ImportExportDetailSearchObject>
    {
        bool Delete(int id);
    }
}
