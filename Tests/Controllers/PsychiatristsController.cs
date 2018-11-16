using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tests.Models;

namespace Tests.Controllers
{
    public class PsychiatristsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Psychiatrists
        public async Task<ActionResult> Index()
        {
            return View(await db.Psychiatrists.ToListAsync());
        }

        // GET: Psychiatrists/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Psychiatrist psychiatrist = await db.Psychiatrists.FindAsync(id);
            if (psychiatrist == null)
            {
                return HttpNotFound();
            }
            return View(psychiatrist);
        }

        // GET: Psychiatrists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Psychiatrists/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] Psychiatrist psychiatrist)
        {
            if (ModelState.IsValid)
            {
                db.Psychiatrists.Add(psychiatrist);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(psychiatrist);
        }

        // GET: Psychiatrists/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Psychiatrist psychiatrist = await db.Psychiatrists.FindAsync(id);
            if (psychiatrist == null)
            {
                return HttpNotFound();
            }
            return View(psychiatrist);
        }

        // POST: Psychiatrists/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] Psychiatrist psychiatrist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(psychiatrist).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(psychiatrist);
        }

        // GET: Psychiatrists/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Psychiatrist psychiatrist = await db.Psychiatrists.FindAsync(id);
            if (psychiatrist == null)
            {
                return HttpNotFound();
            }
            return View(psychiatrist);
        }

        // POST: Psychiatrists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Psychiatrist psychiatrist = await db.Psychiatrists.FindAsync(id);
            db.Psychiatrists.Remove(psychiatrist);
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
