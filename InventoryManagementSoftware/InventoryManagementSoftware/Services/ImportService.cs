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
    public class ImportService : BaseCRUDService<Model.Import, Database.Import, ImportInsertRequest, ImportUpdateRequest, ImportSearchObject>
        , IImportService
    {
        public ImportService(IMSContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IEnumerable<Model.Import> Get(ImportSearchObject search)
        {
            var list = _context.Imports
                .Include(x => x.Supplier).Include(x => x.ImportDetails)
                .AsQueryable();

            if (search?.DateFrom != null && search?.DateTo != null)
                list = list.Where(x => x.Date >= search.DateFrom && x.Date <= search.DateTo);
            if (search?.EmployeeId != null)
                list = list.Where(x => x.EmployeeId == search.EmployeeId);

            return _mapper.Map<List<Model.Import>>(list.ToList());
        }
    }
}
