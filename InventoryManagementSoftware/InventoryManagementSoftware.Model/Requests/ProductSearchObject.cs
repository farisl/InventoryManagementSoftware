using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryManagementSoftware.Model.Requests
{
    public class ProductSearchObject
    {
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
        public int? EmployeeId { get; set; }
        public int? DepartmentId { get; set; }
        [Range(0, 10000)]
        public double? PriceFrom { get; set; }
        [Range(0, 10000)]
        public double? PriceTo { get; set; }
    }
}
