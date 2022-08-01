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
using API1.Models;

namespace API1.Controllers
{
    public class DepartmentController : ApiController
    {
        private DB_Context db = new DB_Context();

        // GET: api/Department
        public IQueryable<Department> GetDepartments()
        {
            return db.Departments;
        }

        // GET: api/Department/5
        [ResponseType(typeof(Department))]
        public IHttpActionResult GetDepartment(long id)
        {
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

        // PUT: api/Department/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDepartment(long id, Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != department.Dep_ID)
            {
                return BadRequest();
            }

            db.Entry(department).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
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

        // POST: api/Department
        [ResponseType(typeof(Department))]
        public IHttpActionResult PostDepartment(Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Departments.Add(department);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = department.Dep_ID }, department);
        }

        // DELETE: api/Department/5
        [ResponseType(typeof(Department))]
        public IHttpActionResult DeleteDepartment(long id)
        {
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }

            db.Departments.Remove(department);
            db.SaveChanges();

            return Ok(department);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DepartmentExists(long id)
        {
            return db.Departments.Count(e => e.Dep_ID == id) > 0;
        }
    }
}