using System;
using System.Collections.Generic;

#nullable disable

namespace InventoryManagementSoftware.Database
{
    public partial class ImportDetail
    {
        public int Id { get; set; }
        public int ImportId { get; set; }
        public int ProductId { get; set; }
        public double Quantity { get; set; }
        public double Discount { get; set; }
        public double Price { get; set; }

        public virtual Import Import { get; set; }
        public virtual Product Product { get; set; }
    }
}
