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
    public class PropertyTypesController : ApiController
    {
        private RealEstateContext db = new RealEstateContext();

        // GET: api/PropertyTypes
        public IQueryable<PropertyType> GetPropertyTypes()
        {
            return db.PropertyTypes;
        }

        // GET: api/PropertyTypes/5
        [ResponseType(typeof(PropertyType))]
        public IHttpActionResult GetPropertyType(int id)
        {
            PropertyType propertyType = db.PropertyTypes.Find(id);
            if (propertyType == null)
            {
                return NotFound();
            }

            return Ok(propertyType);
        }

        // PUT: api/PropertyTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPropertyType(int id, PropertyType propertyType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != propertyType.PropertyTypeID)
            {
                return BadRequest();
            }

            db.Entry(propertyType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyTypeExists(id))
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

        // POST: api/PropertyTypes
        [ResponseType(typeof(PropertyType))]
        public IHttpActionResult PostPropertyType(PropertyType propertyType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PropertyTypes.Add(propertyType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = propertyType.PropertyTypeID }, propertyType);
        }

        // DELETE: api/PropertyTypes/5
        [ResponseType(typeof(PropertyType))]
        public IHttpActionResult DeletePropertyType(int id)
        {
            PropertyType propertyType = db.PropertyTypes.Find(id);
            if (propertyType == null)
            {
                return NotFound();
            }

            db.PropertyTypes.Remove(propertyType);
            db.SaveChanges();

            return Ok(propertyType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PropertyTypeExists(int id)
        {
            return db.PropertyTypes.Count(e => e.PropertyTypeID == id) > 0;
        }
    }
}