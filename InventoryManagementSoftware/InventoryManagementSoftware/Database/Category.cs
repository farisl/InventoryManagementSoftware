using System;
using System.Collections.Generic;

#nullable disable

namespace InventoryManagementSoftware.Database
{
    public partial class Category
    {
        public Category()
        {
            CategoriesBrands = new HashSet<CategoriesBrand>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CategoriesBrand> CategoriesBrands { get; set; }
    }
}
