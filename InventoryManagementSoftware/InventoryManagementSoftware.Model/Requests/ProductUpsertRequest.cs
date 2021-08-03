using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryManagementSoftware.Model.Requests
{
    public class ProductUpsertRequest
    {
        [Required(ErrorMessage = "Name is a Required field")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "CategoryId is a Required field")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "BrandId is a Required field")]
        public int BrandId { get; set; }
        [Range(0, 10000)]
        public double? Price { get; set; }
        public List<ProductAttribue> ProductAttributes { get; set; } = new List<ProductAttribue>();

        public class ProductAttribue
        {
            [Required(ErrorMessage = "AttributeName is a Required field")]
            public string AttributeName { get; set; }
            [Required(ErrorMessage = "AttributeValue is a Required field")]
            public string AttributeValue { get; set; }
        }
    }
}
