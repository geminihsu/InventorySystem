using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventorySample.Models
{
    public class DbHelper
    {
       
        public static void InsertSN(List<Item> items)
        {
            items.ForEach(InsertTable);

        }


        public static void InsertTable(Item item)
        {
            ItemDBContext db = new ItemDBContext();
            db.InventoryItems.Add(item);
            db.SaveChanges();
        }
    }
}