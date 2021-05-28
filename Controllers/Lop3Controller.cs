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
    public class Lop3Controller : ApiController
    {
        private GiasuBotContext db = new GiasuBotContext();

        // GET: api/Lop3
        public IQueryable<Lop3> GetLop3()
        {
            return db.Lop3;
        }

        // GET: api/Lop3/5
        [ResponseType(typeof(Lop3))]
        public IHttpActionResult GetLop3(int id)
        {
            Lop3 lop3 = db.Lop3.Find(id);
            if (lop3 == null)
            {
                return NotFound();
            }

            return Ok(lop3);
        }

        // PUT: api/Lop3/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLop3(int id, Lop3 lop3)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lop3.SubjectId)
            {
                return BadRequest();
            }

            db.Entry(lop3).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Lop3Exists(id))
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

        // POST: api/Lop3
        [ResponseType(typeof(Lop3))]
        public IHttpActionResult PostLop3(Lop3 lop3)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lop3.Add(lop3);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lop3.SubjectId }, lop3);
        }

        // DELETE: api/Lop3/5
        [ResponseType(typeof(Lop3))]
        public IHttpActionResult DeleteLop3(int id)
        {
            Lop3 lop3 = db.Lop3.Find(id);
            if (lop3 == null)
            {
                return NotFound();
            }

            db.Lop3.Remove(lop3);
            db.SaveChanges();

            return Ok(lop3);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Lop3Exists(int id)
        {
            return db.Lop3.Count(e => e.SubjectId == id) > 0;
        }
    }
}