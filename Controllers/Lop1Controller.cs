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
    public class Lop1Controller : ApiController
    {
        private GiasuBotContext db = new GiasuBotContext();

        // GET: api/Lop1
        public IQueryable<Lop1> GetLop1()
        {
            return db.Lop1;
        }

        // GET: api/Lop1/5
        [ResponseType(typeof(Lop1))]
        public IHttpActionResult GetLop1(int id)
        {
            Lop1 lop1 = db.Lop1.Find(id);
            if (lop1 == null)
            {
                return NotFound();
            }

            return Ok(lop1);
        }

        // PUT: api/Lop1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLop1(int id, Lop1 lop1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lop1.SubjectId)
            {
                return BadRequest();
            }

            db.Entry(lop1).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Lop1Exists(id))
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

        // POST: api/Lop1
        [ResponseType(typeof(Lop1))]
        public IHttpActionResult PostLop1(Lop1 lop1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lop1.Add(lop1);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lop1.SubjectId }, lop1);
        }

        // DELETE: api/Lop1/5
        [ResponseType(typeof(Lop1))]
        public IHttpActionResult DeleteLop1(int id)
        {
            Lop1 lop1 = db.Lop1.Find(id);
            if (lop1 == null)
            {
                return NotFound();
            }

            db.Lop1.Remove(lop1);
            db.SaveChanges();

            return Ok(lop1);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Lop1Exists(int id)
        {
            return db.Lop1.Count(e => e.SubjectId == id) > 0;
        }
    }
}