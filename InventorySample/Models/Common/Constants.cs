using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventorySample.Models.Common
{
    public class Constants
    {
        public static string PROJECT_NAME = "Client Service";

        //After scanner the all container, the Container excel file column name ex: MSCU9257505---scanned (16022817)
        public static string CONTAINER_NO = "Container #";
        public static string INVOICE_NO = "Invoice #";
        public static string TOTAL_PICES_RECEIVED = "Total Pieces received:";
        public static string RECEIVED = "Received: ";
        public static string RECEIVED_BY = "Received By:  ";
        public static string ENTERED_CS = "Entered CS:  ";
        public static string ENTERED_PT = "Entered PT:  ";
        public static string SERIAL_NUMBERS = "Serial Numbers:";
        public static string LOCATTION = "Location:";
    }
}