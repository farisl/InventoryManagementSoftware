using System;
using System.Collections.Generic;

#nullable disable

namespace InventoryManagementSoftware.Database
{
    public partial class Attribute
    {
        public Attribute()
        {
            ProductAttributes = new HashSet<ProductAttribute>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProductAttribute> ProductAttributes { get; set; }
    }
}
