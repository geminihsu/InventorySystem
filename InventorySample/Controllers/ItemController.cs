using InventorySample.Entities;
using InventorySample.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace InventorySample.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item_Inventory
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            SampleDBContext db = new SampleDBContext();

            var model = new Container()
            {
                Id = Guid.NewGuid(),
                items = db.Item_transcation_inventory.ToList()
            };

            return Json(model, JsonRequestBehavior.AllowGet);
            
        }
    }
}