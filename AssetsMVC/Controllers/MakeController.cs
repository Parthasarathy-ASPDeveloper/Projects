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
    public class MakeController : Controller
    {
        private AssetsDBContext db = new AssetsDBContext();

        // GET: /Make/
        public async Task<ActionResult> Index()
        {
            return View(await db.mas_make.ToListAsync());
        }

        // GET: /Make/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mas_make mas_make = await db.mas_make.FindAsync(id);
            if (mas_make == null)
            {
                return HttpNotFound();
            }
            return View(mas_make);
        }

        // GET: /Make/Create
        public ActionResult Create()
        {
            ddlLoad();
            return View();
        }

        // POST: /Make/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="id,make,accessoryId,active")] mas_make mas_make)
        {
            if (ModelState.IsValid)
            {
                db.mas_make.Add(mas_make);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(mas_make);
        }

        // GET: /Make/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mas_make mas_make = await db.mas_make.FindAsync(id);
            if (mas_make == null)
            {
                return HttpNotFound();
            }
            return View(mas_make);
        }

        // POST: /Make/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="id,make,accessoryId,active")] mas_make mas_make)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mas_make).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mas_make);
        }

        // GET: /Make/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mas_make mas_make = await db.mas_make.FindAsync(id);
            if (mas_make == null)
            {
                return HttpNotFound();
            }
            return View(mas_make);
        }

        // POST: /Make/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            mas_make mas_make = await db.mas_make.FindAsync(id);
            db.mas_make.Remove(mas_make);
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
        #region SupportingFunctions
        public void ddlLoad()
        {
            List<SelectListItem> accessorylist = new List<SelectListItem>();
            var a = db.mas_Accessory.Select(i => new { i.id, i.accessory });
            foreach (var l in a)
            {
                accessorylist.Add(new SelectListItem
                {
                    Text = l.accessory,
                    Value = l.id.ToString()
                });
            }
            ViewData["Accessory"] = new SelectList(accessorylist, "Value", "Text", "");
        }
        #endregion
    }
}
