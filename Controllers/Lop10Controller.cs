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
    public class Lop10Controller : ApiController
    {
        private GiasuBotContext db = new GiasuBotContext();

        // GET: api/Lop10
        public IQueryable<Lop10> GetLop10()
        {
            return db.Lop10;
        }

        // GET: api/Lop10/5
        [ResponseType(typeof(Lop10))]
        public IHttpActionResult GetLop10(int id)
        {
            Lop10 lop10 = db.Lop10.Find(id);
            if (lop10 == null)
            {
                return NotFound();
            }

            return Ok(lop10);
        }

        // PUT: api/Lop10/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLop10(int id, Lop10 lop10)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lop10.SubjectId)
            {
                return BadRequest();
            }

            db.Entry(lop10).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Lop10Exists(id))
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

        // POST: api/Lop10
        [ResponseType(typeof(Lop10))]
        public IHttpActionResult PostLop10(Lop10 lop10)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lop10.Add(lop10);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lop10.SubjectId }, lop10);
        }

        // DELETE: api/Lop10/5
        [ResponseType(typeof(Lop10))]
        public IHttpActionResult DeleteLop10(int id)
        {
            Lop10 lop10 = db.Lop10.Find(id);
            if (lop10 == null)
            {
                return NotFound();
            }

            db.Lop10.Remove(lop10);
            db.SaveChanges();

            return Ok(lop10);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Lop10Exists(int id)
        {
            return db.Lop10.Count(e => e.SubjectId == id) > 0;
        }
    }
}