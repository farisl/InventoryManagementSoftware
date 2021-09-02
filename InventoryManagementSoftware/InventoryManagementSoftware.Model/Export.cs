using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventoryManagementSoftware.Model
{
    public class Export
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int? InventoryId { get; set; }
        public int? CustomerId { get; set; }
        public int? EmployeeId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<ExportDetail> ExportDetails { get; set; }
        public string CustomerName => Customer?.Name;
        public string ProductsCount => $"{ExportDetails.Sum(x => x.Quantity)} products";
        public string DateString => Date.ToString("yyyy-MM-dd");
    }
}
