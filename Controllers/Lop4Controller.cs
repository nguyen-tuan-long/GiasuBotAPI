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
    public class Lop4Controller : ApiController
    {
        private GiasuBotContext db = new GiasuBotContext();

        // GET: api/Lop4
        public IQueryable<Lop4> GetLop4()
        {
            return db.Lop4;
        }

        // GET: api/Lop4/5
        [ResponseType(typeof(Lop4))]
        public IHttpActionResult GetLop4(int id)
        {
            Lop4 lop4 = db.Lop4.Find(id);
            if (lop4 == null)
            {
                return NotFound();
            }

            return Ok(lop4);
        }

        // PUT: api/Lop4/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLop4(int id, Lop4 lop4)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lop4.SubjectId)
            {
                return BadRequest();
            }

            db.Entry(lop4).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Lop4Exists(id))
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

        // POST: api/Lop4
        [ResponseType(typeof(Lop4))]
        public IHttpActionResult PostLop4(Lop4 lop4)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lop4.Add(lop4);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lop4.SubjectId }, lop4);
        }

        // DELETE: api/Lop4/5
        [ResponseType(typeof(Lop4))]
        public IHttpActionResult DeleteLop4(int id)
        {
            Lop4 lop4 = db.Lop4.Find(id);
            if (lop4 == null)
            {
                return NotFound();
            }

            db.Lop4.Remove(lop4);
            db.SaveChanges();

            return Ok(lop4);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Lop4Exists(int id)
        {
            return db.Lop4.Count(e => e.SubjectId == id) > 0;
        }
    }
}