using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryManagementSoftware.Model.Requests
{
    public class ProductShelfUpsertRequest
    {
        [Required(ErrorMessage = "ProductId is a required field!")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "ShelfId is a required field!")]
        public int ShelfId { get; set; }
        [Required(ErrorMessage = "Quantity is a required field!")]
        [Range(1,10000)]
        public double Quantity { get; set; }
    }
}
