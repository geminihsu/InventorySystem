using InventorySample.Entities;
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
            SampleDBContext db = new SampleDBContext();
            db.Items.Add(item);
            db.SaveChanges();
        }

        public static void DeleteTable(Item item)
        {
            SampleDBContext db = new SampleDBContext();
            Item i = db.Items.Find(item.ID);
            db.Items.Remove(i);
            db.SaveChanges();
        }
    }
    }