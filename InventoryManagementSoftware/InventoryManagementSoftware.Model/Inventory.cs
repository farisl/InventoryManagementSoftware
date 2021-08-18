using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSoftware.Model
{
    public class Inventory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AddressId { get; set; }
        public string PhoneNumber { get; set; }
        public float Size { get; set; }

        public virtual Address Address { get; set; }
        public string Location => $"{Address?.Name}, {Address?.City?.Name}";
        public string SizeStr => $"{Size}m2";
    }
}
