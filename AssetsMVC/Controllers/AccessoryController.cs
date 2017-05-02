using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assets_MVC_.Models;

namespace AssetsMVC.Controllers
{
    public class AccessoryController : Controller
    {
        private AssetsDBContext db = new AssetsDBContext();

        // GET: /Accessory/
        public ActionResult Index()
        {
            return View(db.mas_Accessory.ToList());
        }

        // GET: /Accessory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mas_accessory mas_accessory = db.mas_Accessory.Find(id);
            if (mas_accessory == null)
            {
                return HttpNotFound();
            }
            return View(mas_accessory);
        }

        // GET: /Accessory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Accessory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,accessory,active")] mas_accessory mas_accessory)
        {
            if (ModelState.IsValid)
            {
                db.mas_Accessory.Add(mas_accessory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mas_accessory);
        }

        // GET: /Accessory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mas_accessory mas_accessory = db.mas_Accessory.Find(id);
            if (mas_accessory == null)
            {
                return HttpNotFound();
            }
            return View(mas_accessory);
        }

        // POST: /Accessory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,accessory,active")] mas_accessory mas_accessory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mas_accessory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mas_accessory);
        }

        // GET: /Accessory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mas_accessory mas_accessory = db.mas_Accessory.Find(id);
            if (mas_accessory == null)
            {
                return HttpNotFound();
            }
            return View(mas_accessory);
        }

        // POST: /Accessory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mas_accessory mas_accessory = db.mas_Accessory.Find(id);
            db.mas_Accessory.Remove(mas_accessory);
            db.SaveChanges();
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
