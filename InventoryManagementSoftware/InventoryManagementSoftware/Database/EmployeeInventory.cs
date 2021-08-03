using System;
using System.Collections.Generic;

#nullable disable

namespace InventoryManagementSoftware.Database
{
    public partial class EmployeeInventory
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int InventoryId { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Inventory Inventory { get; set; }
    }
}
