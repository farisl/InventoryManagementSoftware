using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryManagementSoftware.Model.Requests
{
    public class ShelfSearchObject
    {
        public int? DepartmentId { get; set; }
        public string Name { get; set; }
        [Range(0, 1000)]
        public int? RowNumber { get; set; }
    }
}
