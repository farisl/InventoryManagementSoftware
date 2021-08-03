using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSoftware.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public int CategoryBrandId { get; set; }
    }
}
