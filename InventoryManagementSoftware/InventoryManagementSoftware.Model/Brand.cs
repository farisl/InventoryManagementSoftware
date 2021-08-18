using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventoryManagementSoftware.Model
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CategoriesBrand> CategoriesBrands { get; set; }

        public string Categories { get; set; }
}
}
