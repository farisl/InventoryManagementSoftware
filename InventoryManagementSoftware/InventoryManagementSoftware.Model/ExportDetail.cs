using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSoftware.Model
{
    public class ExportDetail
    {
        public int Id { get; set; }
        public int ExportId { get; set; }
        public int ProductId { get; set; }
        public double Quantity { get; set; }
        public double Discount { get; set; }
        public double Price { get; set; }

        public virtual Product Product { get; set; }
        public string ProductName => Product?.Name;
    }
}
