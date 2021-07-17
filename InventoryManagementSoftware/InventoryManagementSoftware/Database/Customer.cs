using System;
using System.Collections.Generic;

#nullable disable

namespace InventoryManagementSoftware.Database
{
    public partial class Customer
    {
        public Customer()
        {
            Exports = new HashSet<Export>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int AddressId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<Export> Exports { get; set; }
    }
}
