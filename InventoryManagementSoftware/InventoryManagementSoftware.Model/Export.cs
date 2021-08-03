using System;
using System.Collections.Generic;
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
    }
}
