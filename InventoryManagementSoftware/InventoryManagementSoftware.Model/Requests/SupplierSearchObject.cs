using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSoftware.Model.Requests
{
    public class SupplierSearchObject
    {
        public string Name { get; set; }
        public int? CityId { get; set; }
    }
}
