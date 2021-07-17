using System;
using System.Collections.Generic;

#nullable disable

namespace InventoryManagementSoftware.Database
{
    public partial class EmployeeSalary
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public double Value { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
