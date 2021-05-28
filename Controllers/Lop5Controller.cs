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
    public class Lop5Controller : ApiController
    {
        private GiasuBotContext db = new GiasuBotContext();

        // GET: api/Lop5
        public IQueryable<Lop5> GetLop5()
        {
            return db.Lop5;
        }

        // GET: api/Lop5/5
        [ResponseType(typeof(Lop5))]
        public IHttpActionResult GetLop5(int id)
        {
            Lop5 lop5 = db.Lop5.Find(id);
            if (lop5 == null)
            {
                return NotFound();
            }

            return Ok(lop5);
        }

        // PUT: api/Lop5/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLop5(int id, Lop5 lop5)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lop5.SubjectId)
            {
                return BadRequest();
            }

            db.Entry(lop5).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Lop5Exists(id))
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

        // POST: api/Lop5
        [ResponseType(typeof(Lop5))]
        public IHttpActionResult PostLop5(Lop5 lop5)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lop5.Add(lop5);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lop5.SubjectId }, lop5);
        }

        // DELETE: api/Lop5/5
        [ResponseType(typeof(Lop5))]
        public IHttpActionResult DeleteLop5(int id)
        {
            Lop5 lop5 = db.Lop5.Find(id);
            if (lop5 == null)
            {
                return NotFound();
            }

            db.Lop5.Remove(lop5);
            db.SaveChanges();

            return Ok(lop5);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Lop5Exists(int id)
        {
            return db.Lop5.Count(e => e.SubjectId == id) > 0;
        }
    }
}