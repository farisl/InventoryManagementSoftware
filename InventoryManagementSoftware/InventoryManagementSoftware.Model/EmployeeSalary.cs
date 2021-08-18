using System;

namespace InventoryManagementSoftware.Model
{
    public class EmployeeSalary
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public double Value { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}