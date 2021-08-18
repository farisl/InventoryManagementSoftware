using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSoftware.Model
{
    public class ProductAttribute
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int AttributeId { get; set; }
        public string Value { get; set; }

        public virtual Attribute Attribute { get; set; }
        public string AttributeName => Attribute?.Name;
    }
}
