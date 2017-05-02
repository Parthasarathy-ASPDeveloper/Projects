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
    public class OwnerController : Controller
    {
        private AssetsDBContext db = new AssetsDBContext();

        // GET: /Owner/
        public async Task<ActionResult> Index()
        {
            return View(await db.mas_owner.ToListAsync());
        }

        // GET: /Owner/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mas_owner mas_owner = await db.mas_owner.FindAsync(id);
            if (mas_owner == null)
            {
                return HttpNotFound();
            }
            return View(mas_owner);
        }

        // GET: /Owner/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Owner/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="id,owner,active")] mas_owner mas_owner)
        {
            if (ModelState.IsValid)
            {
                db.mas_owner.Add(mas_owner);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(mas_owner);
        }

        // GET: /Owner/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mas_owner mas_owner = await db.mas_owner.FindAsync(id);
            if (mas_owner == null)
            {
                return HttpNotFound();
            }
            return View(mas_owner);
        }

        // POST: /Owner/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="id,owner,active")] mas_owner mas_owner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mas_owner).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mas_owner);
        }

        // GET: /Owner/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mas_owner mas_owner = await db.mas_owner.FindAsync(id);
            if (mas_owner == null)
            {
                return HttpNotFound();
            }
            return View(mas_owner);
        }

        // POST: /Owner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            mas_owner mas_owner = await db.mas_owner.FindAsync(id);
            db.mas_owner.Remove(mas_owner);
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
