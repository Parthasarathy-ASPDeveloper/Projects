using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity.Migrations;
using System.Configuration;
using Assets_MVC_.Models;
using AssetsMVC.Models;

namespace AssetsMVC.Controllers
{
    public class LocationController : Controller
    {
        private AssetsDBContext db = new AssetsDBContext();

        //
        // GET: /Location/
        public ActionResult Index()
        {
            ddlLoad();
            //var Key = TableAccessoryEntry();
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection frm)
        {
            ddlLoad();
            //var Key = TableAccessoryEntry();
            return View();
        }

        public ActionResult SwapLocationAssets()
        {
            ddlLoad();
            return View();
        }


        //
        //Post SwapLocationAssets
        [HttpPost]
        public ActionResult SwapLocationAssets(FormCollection frm)
        {
            ddlLoad();
            string Source = frm["Source-Location"].ToString();
            string Destination = frm["Destination-Location"].ToString();
            string mySource = Source;
            string myDestination = Destination;

            bool swap = SwapLocation(mySource, myDestination);

            #region EntityUpdate

            //cpuentry16 c = db.cpuentry16.FirstOrDefault(i => i.assetLocation_id == mySource);
            //cpuentry16 dc = db.cpuentry16.FirstOrDefault(i => i.assetLocation_id == myDestination);

            //if (c != null && dc != null)
            //{

            //    dc.assetLocation_id = mySource;
            //    db.cpuentry16.Attach(c);
            //    db.cpuentry16.AddOrUpdate(dc);
            //    var entry = db.Entry(c);
            //    entry.Property(e => e.assetLocation_id).IsModified = true;
            //    db.SaveChanges();


            //    c.assetLocation_id = myDestination;
            //    db.cpuentry16.Attach(dc);
            //    var entry = db.Entry(dc);
            //    entry.Property(e => e.assetLocation_id).IsModified = true;

            //    db.cpuentry16.AddOrUpdate(c);
            //    db.SaveChanges();
            //}


            //monitorentry16 me = db.monitorentry16.FirstOrDefault(i => i.assetLocation_id == mySource);
            //monitorentry16 dme = db.monitorentry16.FirstOrDefault(i => i.assetLocation_id == myDestination);
            //if (me != null && dme != null)
            //{

            //    dme.assetLocation_id = mySource;

            //    db.monitorentry16.AddOrUpdate(dme);
            //    db.SaveChanges();

            //    me.assetLocation_id = myDestination;
            //    db.monitorentry16.AddOrUpdate(me);
            //    db.SaveChanges();

            //}

            //mouseentry16 m = db.mouseentry16.FirstOrDefault(i => i.assetLocation_id == mySource);
            //mouseentry16 dm = db.mouseentry16.FirstOrDefault(i => i.assetLocation_id == myDestination);
            //if (m != null && dm != null)
            //{
            //    dm.assetLocation_id = mySource;
            //    db.mouseentry16.AddOrUpdate(dm);
            //    db.SaveChanges();


            //    m.assetLocation_id = myDestination;
            //    db.mouseentry16.AddOrUpdate(m);
            //    db.SaveChanges();

            //}

            //keyboardentry16 k = db.keyboardentry16.FirstOrDefault(i => i.assetLocation_id == mySource);
            //keyboardentry16 dk = db.keyboardentry16.FirstOrDefault(i => i.assetLocation_id == myDestination);

            //if (k != null)
            //{
            //    dk.assetLocation_id = mySource;
            //    db.keyboardentry16.AddOrUpdate(dk);
            //    db.SaveChanges();

            //    k.assetLocation_id = myDestination;
            //    db.keyboardentry16.AddOrUpdate(k);
            //    db.SaveChanges();
            //}


            #endregion

            if (swap)
            {
                ViewBag.Message = "Location Swapped Successfully";
            }
            else ViewBag.Message = "Swap Unsuccessful";

            return View();
        }

        //
        // GET: /Location/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Location/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Location/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Location/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Location/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Location/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Location/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        #region AjaxDataSend
        public JsonResult GetTable(string Location)
        {
            var table = TableAccessoryEntry(Location).ToList();
            return Json(table, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region TableQuery
        public List<AccessoriesDisplay> TableAccessoryEntry(string location)
        {
            AccessoriesDisplay c = new AccessoriesDisplay();
            string sSql = "select 'CPU', cpu.asset_id, ma.make, mo.model, o.owner, c.classification, cpu.configuration, cpu.id, '/cpuentry/edit/'" +
                           " from cpuentry16 as cpu " +
                            " left join mas_make as ma on ma.id =cpu.make_id" +
                            " left join mas_model as mo on mo.id =cpu.model_id" +
                            " left join mas_owner as o on o.id =cpu.assetowner" +
                            " left join mas_classification as c on c.id =cpu.classification_id" +
                            " where cpu.assetLocation_id = '" + location + "'" +
                    " Union All" +
                          " select 'Monitor', monitor.asset_id, ma.make, mo.model, o.owner, c.classification, monitor.configuration, monitor.id, '/monitorentry/edit/'" +
                            " from monitorentry16 as monitor " +
                            " left join mas_make as ma on ma.id =monitor.make_id" +
                            " left join mas_model as mo on mo.id =monitor.model_id" +
                            " left join mas_owner as o on o.id =monitor.assetowner" +
                            " left join mas_classification as c on c.id =monitor.classification_id" +
                            " where monitor.assetLocation_id = '" + location + "'" +
                    " Union All" +
                          " select 'Mouse', mouse.asset_id, ma.make, mo.model, o.owner, c.classification, mouse.Type, mouse.id, '/mouse/edit/'" +
                            " from mouseentry16 as mouse " +
                            " left join mas_make as ma on ma.id =mouse.make_id" +
                            " left join mas_model as mo on mo.id =mouse.model_id" +
                            " left join mas_owner as o on o.id =mouse.assetowner" +
                            " left join mas_classification as c on c.id =mouse.classification_id" +
                            " where mouse.assetLocation_id = '" + location + "'" +
                    " Union All" +
                          " select 'Keyboard', keyboard.asset_id, ma.make, mo.model, o.owner, c.classification, keyboard.type, keyboard.id, '/keyboard/edit/'" +
                            " from keyboardentry16 as keyboard " +
                            " left join mas_make as ma on ma.id =keyboard.make_id" +
                            " left join mas_model as mo on mo.id =keyboard.model_id" +
                            " left join mas_owner as o on o.id =keyboard.assetowner" +
                            " left join mas_classification as c on c.id =keyboard.classification_id" +
                            " where keyboard.assetLocation_id = '" + location + "'";

            string connstr = ConfigurationManager.ConnectionStrings["AssetsDB"].ConnectionString;
            SqlConnection cn = new SqlConnection(connstr);
            SqlCommand cmd = new SqlCommand(sSql, cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<AccessoriesDisplay> item = new List<AccessoriesDisplay>();

            while (dr.Read())
            {
                item.Add(
                    new AccessoriesDisplay
                    {

                        name = dr[0].ToString(),
                        asset_id = dr[1].ToString(),
                        make = dr[2].ToString(),
                        model = dr[3].ToString(),
                        owner = dr[4].ToString(),
                        classification = dr[5].ToString(),
                        configuration = Convert.ToString( dr[6].ToString()),
                        id = Convert.ToInt32( dr[7].ToString()),
                        alink = dr[8].ToString() + dr[7].ToString()
                   });
            }
            cn.Close();
            var CPU = from cp in item
                      orderby cp.asset_id
                      select cp;

            return item;
        }
        #endregion
        #region ddlLoad
        public void ddlLoad()
        {
            var m = db.mas_assetlocation.Select(i => new { i.id, i.assetLocation});
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var l in m)
            {
                list.Add(new SelectListItem
                {
                    Text = l.assetLocation,
                    Value = l.assetLocation.ToString()
                });
            }
            ViewData["AssetLocation"] = new SelectList(list, "Value", "Text", "");


        }
        #endregion
        public bool SwapLocation(string source, string destination)
        {
            string dummy = "0000";

            string sSql = "Update cpuentry16 set assetLocation_id = '" + dummy + "' where assetLocation_id = '" + source + "'" +
                                " Update monitorentry16 set assetLocation_id = '" + dummy + "' where assetLocation_id = '" + source + "'" +
                                " Update mouseentry16 set assetLocation_id = '" + dummy + "' where assetLocation_id = '" + source + "'" +
                                " Update keyboardentry16 set assetLocation_id = '" + dummy + "' where assetLocation_id = '" + source + "'" +
                                " Update cpuentry16 set assetLocation_id = '" + source + "' where assetLocation_id = '" + destination + "'" +
                                " Update monitorentry16 set assetLocation_id = '" + source + "' where assetLocation_id = '" + destination + "'" +
                                " Update mouseentry16 set assetLocation_id = '" + source + "' where assetLocation_id = '" + destination + "'" +
                                " Update keyboardentry16 set assetLocation_id = '" + source + "' where assetLocation_id = '" + destination + "'" +
                                " Update cpuentry16 set assetLocation_id = '" + destination + "' where assetLocation_id = '" + dummy + "'" +
                                " Update monitorentry16 set assetLocation_id = '" + destination + "' where assetLocation_id = '" + dummy + "'" +
                                " Update mouseentry16 set assetLocation_id = '" + destination + "' where assetLocation_id = '" + dummy + "'" +
                                " Update keyboardentry16 set assetLocation_id = '" + destination + "' where assetLocation_id = '" + dummy + "'"; 


            string connstr = ConfigurationManager.ConnectionStrings["AssetsDB"].ConnectionString;
            SqlConnection cn = new SqlConnection(connstr);
            SqlCommand cmd = new SqlCommand(sSql, cn);
            cn.Open();
            int update = cmd.ExecuteNonQuery();

            if(update>1)
            {
                return true;
            }
            return false;

        }
    }



}
