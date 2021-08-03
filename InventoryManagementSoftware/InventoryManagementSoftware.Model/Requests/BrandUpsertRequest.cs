using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryManagementSoftware.Model.Requests
{
    public class BrandUpsertRequest
    {
        [Required]
        public string Name { get; set; }
        public List<int> CategoryIds { get; set; } = new List<int>();

    }
}
