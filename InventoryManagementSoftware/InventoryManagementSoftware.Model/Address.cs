namespace InventoryManagementSoftware.Model
{
    public class Address
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }

        public virtual City City { get; set; }
    }
}