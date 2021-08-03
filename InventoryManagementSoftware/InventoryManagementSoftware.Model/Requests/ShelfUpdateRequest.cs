using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryManagementSoftware.Model.Requests
{
    public class ShelfUpdateRequest
    {
        [Required(ErrorMessage = "Name is a Required field")]
        public string Name { get; set; }
        public List<ProductShelf> Products { get; set; } = new List<ProductShelf>();
    }
}
