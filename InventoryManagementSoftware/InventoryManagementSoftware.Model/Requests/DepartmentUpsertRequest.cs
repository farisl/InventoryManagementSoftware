using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryManagementSoftware.Model.Requests
{
    public class DepartmentUpsertRequest
    {
        [Required(ErrorMessage = "InventoryId is a Required field")]
        public int InventoryId { get; set; }
        [Required(ErrorMessage = "Name is a Required field")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Size is a Required field")]
        [Range(0, 10000)]
        public float Size { get; set; }
    }
}
