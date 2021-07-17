using System;
using System.Collections.Generic;

#nullable disable

namespace InventoryManagementSoftware.Database
{
    public partial class Address
    {
        public Address()
        {
            Customers = new HashSet<Customer>();
            Employees = new HashSet<Employee>();
            Inventories = new HashSet<Inventory>();
            Suppliers = new HashSet<Supplier>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
