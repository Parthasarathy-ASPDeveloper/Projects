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
    public class AssetLocationController : Controller
    {
        private AssetsDBContext db = new AssetsDBContext();

        // GET: /AssetLocation/
        public async Task<ActionResult> Index()
        {
            return View(await db.mas_assetlocation.ToListAsync());
        }

        // GET: /AssetLocation/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mas_assetLocation mas_assetlocation = await db.mas_assetlocation.FindAsync(id);
            if (mas_assetlocation == null)
            {
                return HttpNotFound();
            }
            return View(mas_assetlocation);
        }

        // GET: /AssetLocation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /AssetLocation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="id,assetLocation,active")] mas_assetLocation mas_assetlocation)
        {
            if (ModelState.IsValid)
            {
                db.mas_assetlocation.Add(mas_assetlocation);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(mas_assetlocation);
        }

        // GET: /AssetLocation/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mas_assetLocation mas_assetlocation = await db.mas_assetlocation.FindAsync(id);
            if (mas_assetlocation == null)
            {
                return HttpNotFound();
            }
            return View(mas_assetlocation);
        }

        // POST: /AssetLocation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="id,assetLocation,active")] mas_assetLocation mas_assetlocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mas_assetlocation).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mas_assetlocation);
        }

        // GET: /AssetLocation/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mas_assetLocation mas_assetlocation = await db.mas_assetlocation.FindAsync(id);
            if (mas_assetlocation == null)
            {
                return HttpNotFound();
            }
            return View(mas_assetlocation);
        }

        // POST: /AssetLocation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            mas_assetLocation mas_assetlocation = await db.mas_assetlocation.FindAsync(id);
            db.mas_assetlocation.Remove(mas_assetlocation);
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
