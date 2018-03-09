using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASPNETFrameworkWebApp.Models;
using ASPNETFrameworkWebApp.ViewModel;

namespace ASPNETFrameworkWebApp.Controllers
{
    public class AlumnoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Alumno
        public async Task<ActionResult> Index()
        {
            return View(await db.Alumnoes.ToListAsync());
        }

        // GET: Alumno/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumno alumno = await db.Alumnoes.FindAsync(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View(alumno);
        }

        // GET: Alumno/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alumno/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,nombre,apellido")] Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                db.Alumnoes.Add(alumno);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(alumno);
        }

        // GET: Alumno/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumno alumno = await db.Alumnoes.FindAsync(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View(alumno);
        }

        // POST: Alumno/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,nombre,apellido")] Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alumno).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(alumno);
        }

        // GET: Alumno/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumno alumno = await db.Alumnoes.FindAsync(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View(alumno);
        }

        // POST: Alumno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Alumno alumno = await db.Alumnoes.FindAsync(id);
            db.Alumnoes.Remove(alumno);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
