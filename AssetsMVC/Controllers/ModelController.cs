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
    public class ModelController : Controller
    {
        private AssetsDBContext db = new AssetsDBContext();

        // GET: /Model/
        public async Task<ActionResult> Index()
        {
            return View(await db.mas_model.ToListAsync());
        }

        // GET: /Model/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mas_model mas_model = await db.mas_model.FindAsync(id);
            if (mas_model == null)
            {
                return HttpNotFound();
            }
            return View(mas_model);
        }

        // GET: /Model/Create
        public ActionResult Create()
        {
            ddlLoad();
            return View();
        }

        // POST: /Model/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="id,model,make_id,configuration,accessoryId,active")] mas_model mas_model)
        {
            if (ModelState.IsValid)
            {
                db.mas_model.Add(mas_model);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(mas_model);
        }

        // GET: /Model/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mas_model mas_model = await db.mas_model.FindAsync(id);
            if (mas_model == null)
            {
                return HttpNotFound();
            }
            return View(mas_model);
        }

        // POST: /Model/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="id,model,make_id,configuration,accessoryId,active")] mas_model mas_model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mas_model).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mas_model);
        }

        // GET: /Model/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mas_model mas_model = await db.mas_model.FindAsync(id);
            if (mas_model == null)
            {
                return HttpNotFound();
            }
            return View(mas_model);
        }

        // POST: /Model/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            mas_model mas_model = await db.mas_model.FindAsync(id);
            db.mas_model.Remove(mas_model);
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
            var m = db.mas_make.Select(i => new { i.id, i.make });
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var l in m)
            {
                list.Add(new SelectListItem
                {
                    Text = l.make,
                    Value = l.id.ToString()
                });
            }
            ViewData["Make"] = new SelectList(list, "Value", "Text", "");
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
