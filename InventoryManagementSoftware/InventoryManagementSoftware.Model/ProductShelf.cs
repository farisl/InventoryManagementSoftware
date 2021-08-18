using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSoftware.Model
{
    public class ProductShelf
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int ShelfId { get; set; }

        public virtual Product Product { get; set; }
        public string ProductName => Product?.Name;
    }
}
