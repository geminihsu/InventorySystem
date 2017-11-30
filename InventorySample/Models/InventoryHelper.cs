using Excel;
using InventorySample.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using Newtonsoft.Json;

namespace InventorySample.Controllers
{
    public class InventoryHelper
    {

        public static List<Item> shippingFG(IExcelDataReader reader)
        {
            int count = 0;

            Container container = new Container();
            List<Item> inventory = new List<Item>();
            Boolean isCol = false;
            string LocDef = null;
            int itemID = 1;

            do
            {
                while (reader.Read())
                {
                    count = 0;

                    while (count < reader.FieldCount)
                    {
                        String title = reader.GetString(count);

                        if (!isCol && string.Equals(reader.GetString(count), "Serial Numbers:"))
                        {
                            isCol = true;
                            break;
                        }
                        else
                        if (isCol && title != null)
                        {
                            String location = reader.GetString(++count);

                            if (location == null && LocDef != null)
                                location = LocDef;
                            Item item = new Item();
                            item.ID = itemID;
                            item.SN = title;
                            item.Location = location;
                            if (location != null)
                                LocDef = location;

                            itemID++;

                            inventory.Add(item);
                        }
                        else if (!isCol)
                            break;

                        count++;
                    }
                }
            } while (reader.NextResult());

            return inventory;
        }

        public static List<Item> convertShippingFG(DataTable table)
        {
            List<Item> inventory = new List<Item>();

            foreach (DataRow row in table.Rows)
            {
                Console.Write(row["Serial Numbers:"].ToString());
            }
            var d = table.AsEnumerable().Select((x, index) => new {
                SN = x[0],
                Location = x[1]
            }).ToList();


            foreach (object i in d)
            {
                string j = JsonConvert.SerializeObject(i);
                Item deserializedItem = JsonConvert.DeserializeObject<Item>(j);
                inventory.Add(deserializedItem);
            }

            return inventory;
        }
        }
}