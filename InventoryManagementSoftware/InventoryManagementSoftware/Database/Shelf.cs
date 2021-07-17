using System;
using System.Collections.Generic;

#nullable disable

namespace InventoryManagementSoftware.Database
{
    public partial class Shelf
    {
        public Shelf()
        {
            ProductShelves = new HashSet<ProductShelf>();
        }

        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public int RowNumber { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<ProductShelf> ProductShelves { get; set; }
    }
}
