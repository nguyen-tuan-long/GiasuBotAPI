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
    public class Lop2Controller : ApiController
    {
        private GiasuBotContext db = new GiasuBotContext();

        // GET: api/Lop2
        public IQueryable<Lop2> GetLop2()
        {
            return db.Lop2;
        }

        // GET: api/Lop2/5
        [ResponseType(typeof(Lop2))]
        public IHttpActionResult GetLop2(int id)
        {
            Lop2 lop2 = db.Lop2.Find(id);
            if (lop2 == null)
            {
                return NotFound();
            }

            return Ok(lop2);
        }

        // PUT: api/Lop2/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLop2(int id, Lop2 lop2)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lop2.SubjectId)
            {
                return BadRequest();
            }

            db.Entry(lop2).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Lop2Exists(id))
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

        // POST: api/Lop2
        [ResponseType(typeof(Lop2))]
        public IHttpActionResult PostLop2(Lop2 lop2)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lop2.Add(lop2);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lop2.SubjectId }, lop2);
        }

        // DELETE: api/Lop2/5
        [ResponseType(typeof(Lop2))]
        public IHttpActionResult DeleteLop2(int id)
        {
            Lop2 lop2 = db.Lop2.Find(id);
            if (lop2 == null)
            {
                return NotFound();
            }

            db.Lop2.Remove(lop2);
            db.SaveChanges();

            return Ok(lop2);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Lop2Exists(int id)
        {
            return db.Lop2.Count(e => e.SubjectId == id) > 0;
        }
    }
}