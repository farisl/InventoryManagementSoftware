using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryManagementSoftware.Model.Requests
{
    public class InventorySearchObject
    {
        public string Name { get; set; }
        public int? CityId { get; set; }
        [Range(0,10000)]
        public float? SizeFrom { get; set; }
        [Range(0, 10000)]
        public float? SizeTo { get; set; }
    }
}
