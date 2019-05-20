using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CollegeDBEF.DataAccessLayer;
using CollegeDBEF.Models;

namespace Students.API.Controllers
{
    public class StudentsController : ApiController
    {
        private CollegeContext db = new CollegeContext();

        // GET: api/Students
        public IQueryable<CollegeDBEF.Models.Students> GetStudents()
        {
            return db.Students;
        }

        /* Turned off the original method
        // GET: api/Students/5
        [ResponseType(typeof(CollegeDBEF.Models.Students))]
        public IHttpActionResult GetStudents(int id)
        {
            CollegeDBEF.Models.Students students = db.Students.Find(id);
            if (students == null)
            {
                return NotFound();
            }

            return Ok(students);
        } */

        // GET: api/Students/5
        [ResponseType(typeof(CollegeDBEF.Models.Students))]
        public IHttpActionResult GetStudents(int id)
        {
            CollegeDBEF.Models.Students students = db.Students.Find(id);
            if (students == null)
            {
                return NotFound();
            }

            return Ok(students.FName + " " + students.LName);
        }

        // PUT: api/Students/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudents(int id, CollegeDBEF.Models.Students students)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != students.ID)
            {
                return BadRequest();
            }

            db.Entry(students).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentsExists(id))
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

        // POST: api/Students
        [ResponseType(typeof(CollegeDBEF.Models.Students))]
        public IHttpActionResult PostStudents(CollegeDBEF.Models.Students students)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Students.Add(students);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = students.ID }, students);
        }

        // DELETE: api/Students/5
        [ResponseType(typeof(CollegeDBEF.Models.Students))]
        public IHttpActionResult DeleteStudents(int id)
        {
            CollegeDBEF.Models.Students students = db.Students.Find(id);
            if (students == null)
            {
                return NotFound();
            }

            db.Students.Remove(students);
            db.SaveChanges();

            return Ok(students);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentsExists(int id)
        {
            return db.Students.Count(e => e.ID == id) > 0;
        }
    }
}