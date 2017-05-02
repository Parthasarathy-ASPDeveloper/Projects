using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assets_MVC_.Models;

namespace AssetsMVC.Controllers
{
    public class ClassificationController : Controller
    {
        private AssetsDBContext db = new AssetsDBContext();

        // GET: /Classification/
        public async Task<ActionResult> Index()
        {
            return View(await db.mas_classification.ToListAsync());
        }

        // GET: /Classification/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mas_classification mas_classification = await db.mas_classification.FindAsync(id);
            if (mas_classification == null)
            {
                return HttpNotFound();
            }
            return View(mas_classification);
        }

        // GET: /Classification/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Classification/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="id,classification,active")] mas_classification mas_classification)
        {
            if (ModelState.IsValid)
            {
                db.mas_classification.Add(mas_classification);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(mas_classification);
        }

        // GET: /Classification/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mas_classification mas_classification = await db.mas_classification.FindAsync(id);
            if (mas_classification == null)
            {
                return HttpNotFound();
            }
            return View(mas_classification);
        }

        // POST: /Classification/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="id,classification,active")] mas_classification mas_classification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mas_classification).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mas_classification);
        }

        // GET: /Classification/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mas_classification mas_classification = await db.mas_classification.FindAsync(id);
            if (mas_classification == null)
            {
                return HttpNotFound();
            }
            return View(mas_classification);
        }

        // POST: /Classification/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            mas_classification mas_classification = await db.mas_classification.FindAsync(id);
            db.mas_classification.Remove(mas_classification);
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
