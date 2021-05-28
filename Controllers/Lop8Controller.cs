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
    public class Lop8Controller : ApiController
    {
        private GiasuBotContext db = new GiasuBotContext();

        // GET: api/Lop8
        public IQueryable<Lop8> GetLop8()
        {
            return db.Lop8;
        }

        // GET: api/Lop8/5
        [ResponseType(typeof(Lop8))]
        public IHttpActionResult GetLop8(int id)
        {
            Lop8 lop8 = db.Lop8.Find(id);
            if (lop8 == null)
            {
                return NotFound();
            }

            return Ok(lop8);
        }

        // PUT: api/Lop8/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLop8(int id, Lop8 lop8)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lop8.SubjectId)
            {
                return BadRequest();
            }

            db.Entry(lop8).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Lop8Exists(id))
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

        // POST: api/Lop8
        [ResponseType(typeof(Lop8))]
        public IHttpActionResult PostLop8(Lop8 lop8)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lop8.Add(lop8);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lop8.SubjectId }, lop8);
        }

        // DELETE: api/Lop8/5
        [ResponseType(typeof(Lop8))]
        public IHttpActionResult DeleteLop8(int id)
        {
            Lop8 lop8 = db.Lop8.Find(id);
            if (lop8 == null)
            {
                return NotFound();
            }

            db.Lop8.Remove(lop8);
            db.SaveChanges();

            return Ok(lop8);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Lop8Exists(int id)
        {
            return db.Lop8.Count(e => e.SubjectId == id) > 0;
        }
    }
}