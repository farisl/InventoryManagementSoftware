using System;
using System.Collections.Generic;

#nullable disable

namespace InventoryManagementSoftware.Database
{
    public partial class Export
    {
        public Export()
        {
            ExportDetails = new HashSet<ExportDetail>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int? InventoryId { get; set; }
        public int? CustomerId { get; set; }
        public int? EmployeeId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Inventory Inventory { get; set; }
        public virtual ICollection<ExportDetail> ExportDetails { get; set; }
    }
}
