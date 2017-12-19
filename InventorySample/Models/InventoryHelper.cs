using Excel;
using InventorySample.Entities;
using InventorySample.Models;
using InventorySample.Models.Common;
using System;
using System.Collections.Generic;

namespace InventorySample.Controllers
{
    public class InventoryHelper
    {
        public static Guid AddShippingFG(IExcelDataReader reader)
        {
            int ColIndex = 0;

            Container container = new Container();
            String container_no = "";
            String invoice_no = "";
            String total_pieces_received = "";
            String received = "";
            String received_by = "";
            String entered_cs = "";
            String entered_pt = "";
            List<Item_transcation_inventory> items = new List<Item_transcation_inventory>();

            Boolean isSerialNo = false;
            int serialIndex = 1;
            string serialLoc = "";
            int zoneCode = -1;

            do
            {
                while (reader.Read())
                {
                    ColIndex = 0;

                    while (ColIndex < reader.FieldCount)
                    {
                        String title = reader.GetString(ColIndex);
                        if (title != null)
                        {
                            if (isSerialNo)
                            {
                                String serial_no = title;
                                ColIndex++;

                                String location = reader.GetString(ColIndex);

                                if (location == null)
                                    location = serialLoc;
                                else if (location != null)
                                {
                                    zoneCode = MapZoneCode(location);
                                    int locLen = location.Length;
                                    while (locLen < 3)
                                    {
                                        location = "0" + location;
                                        locLen++;
                                    }
                                    serialLoc = location;
                                }

                                Item_transcation_inventory item = new Item_transcation_inventory();
                                item.Seq = serialIndex;
                                item.SN = serial_no;
                                item.ModelNo = serial_no.Substring(0, 6);
                                item.Location = location;
                                DateTime today = DateTime.Now;
                                item.Date = today;



                                items.Add(item);

                                serialIndex++;
                            }
                            else if (string.Equals(reader.GetString(ColIndex), Constants.CONTAINER_NO))
                            {
                                ColIndex += 1;
                                container_no = reader.GetString(ColIndex);
                                ColIndex += 1;
                                title = reader.GetString(ColIndex);

                                if (string.Equals(title, Constants.INVOICE_NO))
                                {
                                    ColIndex += 1;
                                    invoice_no = reader.GetString(ColIndex);
                                }

                                break;
                            }
                            else
                            if (string.Equals(reader.GetString(ColIndex), Constants.TOTAL_PICES_RECEIVED))
                            {
                                ColIndex += 1;
                                total_pieces_received = reader.GetString(ColIndex);
                                ColIndex += 1;
                                title = reader.GetString(ColIndex);

                                if (string.Equals(title, Constants.RECEIVED))
                                {
                                    ColIndex += 1;
                                    received = reader.GetString(ColIndex);
                                }

                                break;
                            }
                            else
                            if (string.Equals(reader.GetString(ColIndex), Constants.RECEIVED_BY))
                            {
                                ColIndex += 1;
                                received_by = reader.GetString(ColIndex);
                                ColIndex += 1;
                                title = reader.GetString(ColIndex);

                                if (string.Equals(title, Constants.ENTERED_CS))
                                {
                                    ColIndex += 1;
                                    entered_cs = reader.GetString(ColIndex);
                                }

                                break;
                            }
                            else
                            if (string.Equals(reader.GetString(ColIndex), Constants.ENTERED_PT))
                            {
                                ColIndex += 1;
                                entered_pt = reader.GetString(ColIndex);
                                break;
                            }
                            else
                            if (string.Equals(reader.GetString(ColIndex), Constants.SERIAL_NUMBERS))
                            {
                                ColIndex += 1;
                                title = reader.GetString(ColIndex);

                                if (string.Equals(title, Constants.LOCATTION))
                                {
                                    isSerialNo = true;
                                    break;
                                }
                            }
                        }
                        ColIndex++;
                    }
                }
            } while (reader.NextResult());

            container.Id = new Guid();
            container.ContainerNo = container_no;
            container.InvoiceNo = invoice_no;
            container.PiceRecevid = total_pieces_received;
            container.RecevidDate = received;
            container.WorkerInfo = received_by;
            container.EnteredCS = entered_cs;
            container.EnteredPT = entered_pt;
            container.items = items;

            ContainerMapping.AddOrUpdateCache(container);

            return container.Id;
        }

        public static Container CheckAndGetContainerModel(Guid fileId)
        {
            return ContainerMapping.CheckAndGetCacheModel(fileId);
        }

        private static int MapZoneCode(String location)
        {
            int code = -1;
            int locNum = Int32.Parse(location);

            if (locNum == Constants.ZONE_CODE_4_ONE)
                code = Constants.ZONE_CODE_4;
            else if (locNum >= Constants.ZONE_CODE_1_MIN && locNum <= Constants.ZONE_CODE_1_MAX)
                code = Constants.ZONE_CODE_1;
            else if (locNum >= Constants.ZONE_CODE_2_MIN && locNum <= Constants.ZONE_CODE_2_MAX)
            {
                if (locNum % 10 == 1 || locNum % 10 == 2)
                    code = Constants.ZONE_CODE_2;
            }
            else if (locNum == Constants.ZONE_CODE_3_A || locNum == Constants.ZONE_CODE_3_B || locNum == Constants.ZONE_CODE_3_C || locNum == Constants.ZONE_CODE_3_D)
            {
                code = Constants.ZONE_CODE_3;
            }

            return code;
        }
    }
}