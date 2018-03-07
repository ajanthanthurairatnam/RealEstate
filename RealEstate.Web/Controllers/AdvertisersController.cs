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
    public class AdvertisersController : ApiController
    {
        private RealEstateContext db = new RealEstateContext();

        // GET: api/Advertisers
        public IQueryable<Advertiser> GetAdvertiser()
        {
            return db.Advertiser;
        }

        // GET: api/Advertisers/5
        [ResponseType(typeof(Advertiser))]
        public IHttpActionResult GetAdvertiser(int id)
        {
            Advertiser advertiser = db.Advertiser.Find(id);
            if (advertiser == null)
            {
                return NotFound();
            }

            return Ok(advertiser);
        }

        // PUT: api/Advertisers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdvertiser(int id, Advertiser advertiser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != advertiser.AdvertiserId)
            {
                return BadRequest();
            }

            db.Entry(advertiser).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdvertiserExists(id))
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

        // POST: api/Advertisers
        [ResponseType(typeof(Advertiser))]
        public IHttpActionResult PostAdvertiser(Advertiser advertiser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Advertiser.Add(advertiser);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = advertiser.AdvertiserId }, advertiser);
        }

        // DELETE: api/Advertisers/5
        [ResponseType(typeof(Advertiser))]
        public IHttpActionResult DeleteAdvertiser(int id)
        {
            Advertiser advertiser = db.Advertiser.Find(id);
            if (advertiser == null)
            {
                return NotFound();
            }

            db.Advertiser.Remove(advertiser);
            db.SaveChanges();

            return Ok(advertiser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdvertiserExists(int id)
        {
            return db.Advertiser.Count(e => e.AdvertiserId == id) > 0;
        }
    }
}