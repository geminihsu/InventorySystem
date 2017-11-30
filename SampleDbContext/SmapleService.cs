using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace SampleDbContext
{
    public class SmapleService
    {
        public string MyProperty { get; set; }

        public void Show()
        {
            Console.WriteLine("Heello");
        }

       
    }
}