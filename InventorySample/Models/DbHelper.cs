using System.Collections.Generic;

namespace InventorySample.Models
{
    public class DbHelper
    {
        public static void InsertSN(List<Item> items)
        {
            items.ForEach(InsertTable);
        }

        public static void DeleteSN(List<Item> items)
        {
            items.ForEach(DeleteTable);
        }

        public static void InsertTable(Item item)
        {
            ItemDBContext db = new ItemDBContext();
            db.InventoryItems.Add(item);
            db.SaveChanges();
        }

        public static void DeleteTable(Item item)
        {
            ItemDBContext db = new ItemDBContext();
            Item i = db.InventoryItems.Find(item.Id);
            db.InventoryItems.Remove(i);
            db.SaveChanges();
        }
    }
    }