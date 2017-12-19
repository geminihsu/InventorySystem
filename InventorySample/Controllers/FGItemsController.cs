using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using InventorySample.Entities;

namespace InventorySample.Controllers
{
    public class FGItemsController : ApiController
    {
        private SampleDBContext db = new SampleDBContext();

        // GET: api/FGItems
        public IQueryable<Item_transcation_inventory> GetItem_transcation_inventory()
        {
            return db.Item_transcation_inventory;
        }

        // GET: api/FGItems/5
        [ResponseType(typeof(Item_transcation_inventory))]
        public IHttpActionResult GetItem_transcation_inventory(int id)
        {
            Item_transcation_inventory item_transcation_inventory = db.Item_transcation_inventory.Find(id);
            if (item_transcation_inventory == null)
            {
                return NotFound();
            }

            return Ok(item_transcation_inventory);
        }

        // PUT: api/FGItems/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutItem_transcation_inventory(int id, Item_transcation_inventory item_transcation_inventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != item_transcation_inventory.Seq)
            {
                return BadRequest();
            }

            db.Entry(item_transcation_inventory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Item_transcation_inventoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/FGItems
        [ResponseType(typeof(Item_transcation_inventory))]
        public IHttpActionResult PostItem_transcation_inventory(Item_transcation_inventory item_transcation_inventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Item_transcation_inventory.Add(item_transcation_inventory);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Item_transcation_inventoryExists(item_transcation_inventory.Seq))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = item_transcation_inventory.Seq }, item_transcation_inventory);
        }

        // DELETE: api/FGItems/5
        [ResponseType(typeof(Item_transcation_inventory))]
        public IHttpActionResult DeleteItem_transcation_inventory(int id)
        {
            Item_transcation_inventory item_transcation_inventory = db.Item_transcation_inventory.Find(id);
            if (item_transcation_inventory == null)
            {
                return NotFound();
            }

            db.Item_transcation_inventory.Remove(item_transcation_inventory);
            db.SaveChanges();

            return Ok(item_transcation_inventory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Item_transcation_inventoryExists(int id)
        {
            return db.Item_transcation_inventory.Count(e => e.Seq == id) > 0;
        }
    }
}