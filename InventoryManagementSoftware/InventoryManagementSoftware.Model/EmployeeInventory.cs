using System;

namespace InventoryManagementSoftware.Model
{
    public class EmployeeInventory
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int InventoryId { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Inventory Inventory { get; set; }
    }
}