using AutoMapper;
using InventoryManagementSoftware.Database;
using InventoryManagementSoftware.Model.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSoftware.Services
{
    public class ExportService : BaseCRUDService<Model.Export, Database.Export, ExportInsertRequest, ExportUpdateRequest, ExportSearchObject>
        , IExportService
    {
        public ExportService(IMSContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IEnumerable<Model.Export> Get(ExportSearchObject search)
        {
            var list = _context.Exports
                .Include(x => x.Customer).Include(x => x.ExportDetails).Include(x => x.Inventory)
                .AsQueryable();

            if (search?.DateFrom != null && search?.DateTo != null)
                list = list.Where(x => x.Date >= search.DateFrom && x.Date <= search.DateTo);
            if (search?.EmployeeId != null)
                list = list.Where(x => x.EmployeeId == search.EmployeeId);

            return _mapper.Map<List<Model.Export>>(list.ToList());
        }

    }
}
