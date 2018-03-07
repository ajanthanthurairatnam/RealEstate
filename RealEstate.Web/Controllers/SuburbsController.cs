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
using RealEstate.Web.Models;

namespace RealEstate.Web.Controllers
{
    public class SuburbsController : ApiController
    {
        private RealEstateContext db = new RealEstateContext();

        // GET: api/Suburbs
        public IQueryable<Suburb> GetSuburbs()
        {
            return db.Suburbs;
        }

        // GET: api/Suburbs/5
        [ResponseType(typeof(Suburb))]
        public IHttpActionResult GetSuburb(int id)
        {
            Suburb suburb = db.Suburbs.Find(id);
            if (suburb == null)
            {
                return NotFound();
            }

            return Ok(suburb);
        }

        // PUT: api/Suburbs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSuburb(int id, Suburb suburb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != suburb.SuburbID)
            {
                return BadRequest();
            }

            db.Entry(suburb).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuburbExists(id))
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

        // POST: api/Suburbs
        [ResponseType(typeof(Suburb))]
        public IHttpActionResult PostSuburb(Suburb suburb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Suburbs.Add(suburb);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = suburb.SuburbID }, suburb);
        }

        // DELETE: api/Suburbs/5
        [ResponseType(typeof(Suburb))]
        public IHttpActionResult DeleteSuburb(int id)
        {
            Suburb suburb = db.Suburbs.Find(id);
            if (suburb == null)
            {
                return NotFound();
            }

            db.Suburbs.Remove(suburb);
            db.SaveChanges();

            return Ok(suburb);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SuburbExists(int id)
        {
            return db.Suburbs.Count(e => e.SuburbID == id) > 0;
        }
    }
}