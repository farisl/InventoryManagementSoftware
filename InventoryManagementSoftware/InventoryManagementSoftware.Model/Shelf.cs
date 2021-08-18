using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventoryManagementSoftware.Model
{
    public class Shelf
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public int RowNumber { get; set; }

        public virtual ICollection<ProductShelf> ProductShelves { get; set; }
        public int? ProductsCount => ProductShelves?.Sum(x => x.Quantity);
    }
}
