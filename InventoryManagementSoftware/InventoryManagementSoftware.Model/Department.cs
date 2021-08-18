using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSoftware.Model
{
    public class Department
    {
        public int Id { get; set; }
        public int InventoryId { get; set; }
        public string Name { get; set; }
        public float Size { get; set; }


        public virtual Inventory Inventory { get; set; }
        public string DepartmentSize => $"{Size}m2";
        public string DepartmentName => $"{Name} - inv. {Inventory?.Name}";
    }
}
