using System.Data.Entity;

namespace InventorySample.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string SN { get; set; }
        public string Location { get; set; }
        public int ZoneCode { get; set; }
    }

    public class ItemDBContext : DbContext
    {
        public ItemDBContext() : base(nameOrConnectionString: "SampleConnection")
        {
        }

        public DbSet<Item> InventoryItems { get; set; }
    }
}