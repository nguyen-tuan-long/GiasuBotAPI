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
    public class Lop11Controller : ApiController
    {
        private GiasuBotContext db = new GiasuBotContext();

        // GET: api/Lop11
        public IQueryable<Lop11> GetLop11()
        {
            return db.Lop11;
        }

        // GET: api/Lop11/5
        [ResponseType(typeof(Lop11))]
        public IHttpActionResult GetLop11(int id)
        {
            Lop11 lop11 = db.Lop11.Find(id);
            if (lop11 == null)
            {
                return NotFound();
            }

            return Ok(lop11);
        }

        // PUT: api/Lop11/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLop11(int id, Lop11 lop11)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lop11.SubjectId)
            {
                return BadRequest();
            }

            db.Entry(lop11).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Lop11Exists(id))
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

        // POST: api/Lop11
        [ResponseType(typeof(Lop11))]
        public IHttpActionResult PostLop11(Lop11 lop11)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lop11.Add(lop11);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lop11.SubjectId }, lop11);
        }

        // DELETE: api/Lop11/5
        [ResponseType(typeof(Lop11))]
        public IHttpActionResult DeleteLop11(int id)
        {
            Lop11 lop11 = db.Lop11.Find(id);
            if (lop11 == null)
            {
                return NotFound();
            }

            db.Lop11.Remove(lop11);
            db.SaveChanges();

            return Ok(lop11);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Lop11Exists(int id)
        {
            return db.Lop11.Count(e => e.SubjectId == id) > 0;
        }
    }
}