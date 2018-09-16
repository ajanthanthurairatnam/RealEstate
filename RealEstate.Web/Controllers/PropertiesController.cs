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
    public class PropertiesController : ApiController
    {
        private RealEstateContext db = new RealEstateContext();

        // GET: api/Properties
        public IEnumerable<Object> GetProperties()
        {

            //Have TO Reevaluate This
            var Properties = db.Properties.Select(e => new            
            {
                AddressLine1 = e.AddressLine1,
                AddressLine2 = e.AddressLine2,
                AddressLine3 = e.AddressLine3,
                //Advertiser=db.Advertiser.Where(c => c.AdvertiserId == e.AdvertiserId).FirstOrDefault(),
                Advertiser = e.Advertiser,
                AdvertiserId = e.AdvertiserId,
                BathRooms = e.BathRooms,
                ContactEmail = e.ContactEmail,
                ContactMobile = e.ContactMobile,
                ContactName = e.ContactName,
                ContactPhone = e.ContactPhone,
                // Country = db.Countries.Where(c => c.CountryID == e.CountryId).FirstOrDefault(),
                Country = e.Country,
                CountryId = e.CountryId,
                PropertyBedRooms = e.PropertyBedRooms,
                PropertyCarParks = e.PropertyCarParks,
                PropertyDescription = e.PropertyDescription,
                PropertyID = e.PropertyID,
                PropertyInspectionDetail = e.PropertyInspectionDetail,
                PropertyIsForSale = e.PropertyIsForSale,
                PropertyLandSize = e.PropertyLandSize,
                PropertyMap = e.PropertyMap,
                PropertyPrice = e.PropertyPrice,
                // PropertyType  = db.PropertyTypes.Where(c => c.PropertyTypeID == e.PropertyTypeId).FirstOrDefault(),
                PropertyType = e.PropertyType,
                PropertyTypeId = e.PropertyTypeId,
                //State = db.States.Where(c => c.StateID == e.StateId).FirstOrDefault(),
                State = e.State,
                StateId = e.StateId,
                //Suburb = db.Suburbs.Where(c => c.SuburbID == e.SuburburbId).FirstOrDefault(),
                Suburb = e.Suburb,
                SuburburbId = e.SuburburbId,
                WeeklyRent = e.WeeklyRent

            }).ToList();

                return Properties;
        }

        // GET: api/Properties/5
        [ResponseType(typeof(Property))]
        public IHttpActionResult GetProperty(int id)
        {
            Property property = db.Properties.Find(id);
            if (property == null)
            {
                return NotFound();
            }

            return Ok(property);
        }

        // PUT: api/Properties/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProperty(int id, Property property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != property.PropertyID)
            {
                return BadRequest();
            }

            db.Entry(property).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyExists(id))
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

        // POST: api/Properties
        [ResponseType(typeof(Property))]
        public IHttpActionResult PostProperty(Property property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Properties.Add(property);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = property.PropertyID }, property);
        }

        // DELETE: api/Properties/5
        [ResponseType(typeof(Property))]
        public IHttpActionResult DeleteProperty(int id)
        {
            Property property = db.Properties.Find(id);
            if (property == null)
            {
                return NotFound();
            }

            db.Properties.Remove(property);
            db.SaveChanges();

            return Ok(property);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PropertyExists(int id)
        {
            return db.Properties.Count(e => e.PropertyID == id) > 0;
        }
    }
}