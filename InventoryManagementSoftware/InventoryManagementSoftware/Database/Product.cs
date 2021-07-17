using System;
using System.Collections.Generic;

#nullable disable

namespace InventoryManagementSoftware.Database
{
    public partial class Product
    {
        public Product()
        {
            ExportDetails = new HashSet<ExportDetail>();
            ImportDetails = new HashSet<ImportDetail>();
            ProductAttributes = new HashSet<ProductAttribute>();
            ProductPrices = new HashSet<ProductPrice>();
            ProductShelves = new HashSet<ProductShelf>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public int CategoryBrandId { get; set; }

        public virtual CategoriesBrand CategoryBrand { get; set; }
        public virtual ICollection<ExportDetail> ExportDetails { get; set; }
        public virtual ICollection<ImportDetail> ImportDetails { get; set; }
        public virtual ICollection<ProductAttribute> ProductAttributes { get; set; }
        public virtual ICollection<ProductPrice> ProductPrices { get; set; }
        public virtual ICollection<ProductShelf> ProductShelves { get; set; }
    }
}
