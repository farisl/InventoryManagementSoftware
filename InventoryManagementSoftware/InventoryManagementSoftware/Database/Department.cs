using System;
using System.Collections.Generic;

#nullable disable

namespace InventoryManagementSoftware.Database
{
    public partial class Department
    {
        public Department()
        {
            Shelves = new HashSet<Shelf>();
        }

        public int Id { get; set; }
        public int InventoryId { get; set; }
        public string Name { get; set; }
        public float Size { get; set; }

        public virtual Inventory Inventory { get; set; }
        public virtual ICollection<Shelf> Shelves { get; set; }
    }
}
