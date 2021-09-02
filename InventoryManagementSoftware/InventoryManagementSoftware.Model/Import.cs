using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventoryManagementSoftware.Model
{
    public class Import
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int? InventoryId { get; set; }
        public int? SupplierId { get; set; }
        public int? EmployeeId { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<ImportDetail> ImportDetails { get; set; }
        public string SupplierName => Supplier?.Name;
        public string ProductsCount => $"{ImportDetails.Sum(x => x.Quantity)} products";
        public string DateString => Date.ToString("yyyy-MM-dd");

    }
}
