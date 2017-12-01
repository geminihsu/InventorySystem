using InventorySample.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventorySample.Models
{
    public class Container
    {
        public Guid Id { get; set; }
        public string ContainerNo { get; set; }
        public string InvoiceNo { get; set; }
        public string PiceRecevid { get; set; }
        public string RecevidDate { get; set; }
        public string WorkerInfo { get; set; }
        public string EnteredCS { get; set; }
        public string EnteredPT { get; set; }

        public List<Item> items { get; set; }
    }
}

//http://www.entityframeworktutorial.net/