using InventorySample.Entities;
using System.Collections.Generic;

namespace InventorySample.Models
{
    public class DbHelper
    {
        public static void InsertSN(List<Item_transcation_inventory> items)
        {
            items.ForEach(InsertTable);
        }

        public static void DeleteSN(List<Item_transcation_inventory> items)
        {
            items.ForEach(DeleteTable);
        }

        public static void InsertTable(Item_transcation_inventory item)
        {
            SampleDBContext db = new SampleDBContext();
            db.Item_transcation_inventory.Add(item);
            db.SaveChanges();
        }

        public static void DeleteTable(Item_transcation_inventory item)
        {
            SampleDBContext db = new SampleDBContext();
            Item_transcation_inventory i = db.Item_transcation_inventory.Find(item.SN);
            db.Item_transcation_inventory.Remove(i);
            db.SaveChanges();
        }
    }
    }