using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryManagementSoftware.Model.Requests
{
    public class ProductAttributeUpsertRequest
    {
        [Required(ErrorMessage = "ProductId is a required field!")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "AttributeName is a required field!")]
        public string AttributeName { get; set; }
        [Required(ErrorMessage = "Value is a required field!")]
        public string Value { get; set; }
    }
}
