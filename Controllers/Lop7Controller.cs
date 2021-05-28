using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using GiasuBotAPI.Models;

namespace GiasuBotAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Lop7Controller : ApiController
    {
        private GiasuBotContext db = new GiasuBotContext();

        // GET: api/Lop7
        public IQueryable<Lop7> GetLop7()
        {
            return db.Lop7;
        }

        // GET: api/Lop7/5
        [ResponseType(typeof(Lop7))]
        public IHttpActionResult GetLop7(int id)
        {
            Lop7 lop7 = db.Lop7.Find(id);
            if (lop7 == null)
            {
                return NotFound();
            }

            return Ok(lop7);
        }

        // PUT: api/Lop7/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLop7(int id, Lop7 lop7)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lop7.SubjectId)
            {
                return BadRequest();
            }

            db.Entry(lop7).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Lop7Exists(id))
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

        // POST: api/Lop7
        [ResponseType(typeof(Lop7))]
        public IHttpActionResult PostLop7(Lop7 lop7)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lop7.Add(lop7);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lop7.SubjectId }, lop7);
        }

        // DELETE: api/Lop7/5
        [ResponseType(typeof(Lop7))]
        public IHttpActionResult DeleteLop7(int id)
        {
            Lop7 lop7 = db.Lop7.Find(id);
            if (lop7 == null)
            {
                return NotFound();
            }

            db.Lop7.Remove(lop7);
            db.SaveChanges();

            return Ok(lop7);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Lop7Exists(int id)
        {
            return db.Lop7.Count(e => e.SubjectId == id) > 0;
        }
    }
}