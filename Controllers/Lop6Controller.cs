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
    public class Lop6Controller : ApiController
    {
        private GiasuBotContext db = new GiasuBotContext();

        // GET: api/Lop6
        public IQueryable<Lop6> GetLop6()
        {
            return db.Lop6;
        }

        // GET: api/Lop6/5
        [ResponseType(typeof(Lop6))]
        public IHttpActionResult GetLop6(int id)
        {
            Lop6 lop6 = db.Lop6.Find(id);
            if (lop6 == null)
            {
                return NotFound();
            }

            return Ok(lop6);
        }

        // PUT: api/Lop6/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLop6(int id, Lop6 lop6)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lop6.SubjectId)
            {
                return BadRequest();
            }

            db.Entry(lop6).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Lop6Exists(id))
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

        // POST: api/Lop6
        [ResponseType(typeof(Lop6))]
        public IHttpActionResult PostLop6(Lop6 lop6)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lop6.Add(lop6);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lop6.SubjectId }, lop6);
        }

        // DELETE: api/Lop6/5
        [ResponseType(typeof(Lop6))]
        public IHttpActionResult DeleteLop6(int id)
        {
            Lop6 lop6 = db.Lop6.Find(id);
            if (lop6 == null)
            {
                return NotFound();
            }

            db.Lop6.Remove(lop6);
            db.SaveChanges();

            return Ok(lop6);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Lop6Exists(int id)
        {
            return db.Lop6.Count(e => e.SubjectId == id) > 0;
        }
    }
}