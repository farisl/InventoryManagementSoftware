using System;
using System.Collections.Generic;
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
    }
}
