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
    public class Lop12Controller : ApiController
    {
        private GiasuBotContext db = new GiasuBotContext();

        // GET: api/Lop12
        public IQueryable<Lop12> GetLop12()
        {
            return db.Lop12;
        }

        // GET: api/Lop12/5
        [ResponseType(typeof(Lop12))]
        public IHttpActionResult GetLop12(int id)
        {
            Lop12 lop12 = db.Lop12.Find(id);
            if (lop12 == null)
            {
                return NotFound();
            }

            return Ok(lop12);
        }

        // PUT: api/Lop12/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLop12(int id, Lop12 lop12)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lop12.SubjectId)
            {
                return BadRequest();
            }

            db.Entry(lop12).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Lop12Exists(id))
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

        // POST: api/Lop12
        [ResponseType(typeof(Lop12))]
        public IHttpActionResult PostLop12(Lop12 lop12)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lop12.Add(lop12);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lop12.SubjectId }, lop12);
        }

        // DELETE: api/Lop12/5
        [ResponseType(typeof(Lop12))]
        public IHttpActionResult DeleteLop12(int id)
        {
            Lop12 lop12 = db.Lop12.Find(id);
            if (lop12 == null)
            {
                return NotFound();
            }

            db.Lop12.Remove(lop12);
            db.SaveChanges();

            return Ok(lop12);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Lop12Exists(int id)
        {
            return db.Lop12.Count(e => e.SubjectId == id) > 0;
        }
    }
}