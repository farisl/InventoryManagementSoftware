using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryManagementSoftware.Model.Requests
{
    public class ShelfInsertRequest
    {
        [Required(ErrorMessage = "DepartmentId is a Required field")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Name is a Required field")]
        public string Name { get; set; }
        [Required(ErrorMessage = "RowNumber is a Required field")]
        [Range(0, 1000)]
        public int RowNumber { get; set; }
    }
}
