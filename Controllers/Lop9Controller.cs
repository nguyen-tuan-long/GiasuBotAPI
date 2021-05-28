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
    public class Lop9Controller : ApiController
    {
        private GiasuBotContext db = new GiasuBotContext();

        // GET: api/Lop9
        public IQueryable<Lop9> GetLop9()
        {
            return db.Lop9;
        }

        // GET: api/Lop9/5
        [ResponseType(typeof(Lop9))]
        public IHttpActionResult GetLop9(int id)
        {
            Lop9 lop9 = db.Lop9.Find(id);
            if (lop9 == null)
            {
                return NotFound();
            }

            return Ok(lop9);
        }

        // PUT: api/Lop9/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLop9(int id, Lop9 lop9)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lop9.SubjectId)
            {
                return BadRequest();
            }

            db.Entry(lop9).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Lop9Exists(id))
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

        // POST: api/Lop9
        [ResponseType(typeof(Lop9))]
        public IHttpActionResult PostLop9(Lop9 lop9)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lop9.Add(lop9);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lop9.SubjectId }, lop9);
        }

        // DELETE: api/Lop9/5
        [ResponseType(typeof(Lop9))]
        public IHttpActionResult DeleteLop9(int id)
        {
            Lop9 lop9 = db.Lop9.Find(id);
            if (lop9 == null)
            {
                return NotFound();
            }

            db.Lop9.Remove(lop9);
            db.SaveChanges();

            return Ok(lop9);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Lop9Exists(int id)
        {
            return db.Lop9.Count(e => e.SubjectId == id) > 0;
        }
    }
}