namespace InventoryManagementSoftware.Model
{
    public class CategoriesBrand
    {
        public int BrandId { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}