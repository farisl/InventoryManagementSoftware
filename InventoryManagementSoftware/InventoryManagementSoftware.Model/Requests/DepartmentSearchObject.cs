using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryManagementSoftware.Model.Requests
{
    public class DepartmentSearchObject
    {
        public int? InventoryId { get; set; }
        public string Name { get; set; }
        [Range(0,10000)]
        public float? SizeFrom { get; set; }
        [Range(0, 10000)]
        public float? SizeTo { get; set; }

        public int? EmployeeId { get; set; }
    }
}
