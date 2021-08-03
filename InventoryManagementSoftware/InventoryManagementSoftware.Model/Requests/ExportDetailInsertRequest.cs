using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryManagementSoftware.Model.Requests
{
    public class ExportDetailInsertRequest
    {
        [Required(ErrorMessage = "ExportId is a Required field")]
        public int ExportId { get; set; }
        [Required(ErrorMessage = "ProductId is a Required field")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Quantity is a Required field")]
        [Range(1,10000)]
        public double Quantity { get; set; }
        [Required(ErrorMessage = "Discount is a Required field")]
        [Range(0, 1, ErrorMessage ="Discount must be between 0 and 1")]
        public double Discount { get; set; }
    }
}
