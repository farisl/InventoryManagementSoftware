using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSoftware.Model.Requests
{
    public class BrandSearchObject
    {
        public string Name { get; set; }
        public List<int> CategoryIds { get; set; } = new List<int>();
    }
}
