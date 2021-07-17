using System;
using System.Collections.Generic;

#nullable disable

namespace InventoryManagementSoftware.Database
{
    public partial class ExportDetail
    {
        public int Id { get; set; }
        public int ExportId { get; set; }
        public int ProductId { get; set; }
        public double Quantity { get; set; }
        public double Discount { get; set; }
        public double Price { get; set; }

        public virtual Export Export { get; set; }
        public virtual Product Product { get; set; }
    }
}
