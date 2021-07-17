using System;
using System.Collections.Generic;

#nullable disable

namespace InventoryManagementSoftware.Database
{
    public partial class Inventory
    {
        public Inventory()
        {
            Departments = new HashSet<Department>();
            EmployeeInventories = new HashSet<EmployeeInventory>();
            Exports = new HashSet<Export>();
            Imports = new HashSet<Import>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int AddressId { get; set; }
        public string PhoneNumber { get; set; }
        public float Size { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<EmployeeInventory> EmployeeInventories { get; set; }
        public virtual ICollection<Export> Exports { get; set; }
        public virtual ICollection<Import> Imports { get; set; }
    }
}
