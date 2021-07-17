using System;
using System.Collections.Generic;

#nullable disable

namespace InventoryManagementSoftware.Database
{
    public partial class ProductShelf
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ShelfId { get; set; }
        public double Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual Shelf Shelf { get; set; }
    }
}
