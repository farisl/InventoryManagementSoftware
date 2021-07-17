using System;
using System.Collections.Generic;

#nullable disable

namespace InventoryManagementSoftware.Database
{
    public partial class Import
    {
        public Import()
        {
            ImportDetails = new HashSet<ImportDetail>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int? InventoryId { get; set; }
        public int? SupplierId { get; set; }
        public int? EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Inventory Inventory { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<ImportDetail> ImportDetails { get; set; }
    }
}
