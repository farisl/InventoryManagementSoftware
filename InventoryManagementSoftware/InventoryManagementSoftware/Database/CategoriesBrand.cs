using System;
using System.Collections.Generic;

#nullable disable

namespace InventoryManagementSoftware.Database
{
    public partial class CategoriesBrand
    {
        public CategoriesBrand()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
