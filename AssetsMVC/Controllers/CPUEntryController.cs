using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using System.Web.Mvc;
using ClosedXML;
using ClosedXML.Excel;
using Assets_MVC_.Models;
using AssetsMVC.Models;

namespace AssetsMVC.Controllers
{
    public class CPUEntryController : Controller
    {
        private AssetsDBContext db = new AssetsDBContext();

        // GET: /CPUEntry/
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {


                var CPU = TableCPUEntry().ToList();
                return View(CPU);
            }
            else return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult ExportData()
        {
            GridView gv = new GridView();
            gv.DataSource = TableCPUEntry();
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=Consolidated CPU Details.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            gv.HeaderRow.Style.Add("width", "15%");
            gv.HeaderRow.Style.Add("font-size", "10px");
            gv.Style.Add("text-decoration", "none");
            gv.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
            gv.Style.Add("font-size", "26px");
            for (int col = 0; col < gv.HeaderRow.Controls.Count; col++)
            {
                TableCell tc = gv.HeaderRow.Cells[col];
                tc.Style.Add("color", "#FFFFFF");
                tc.Style.Add("background-color", "#444");
            }
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();


            //using (XLWorkbook wb = new XLWorkbook())
            //{
            //    wb.Worksheets.Add();
            //    wb.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            //    wb.Style.Font.Bold = true;

            //    Response.Clear();
            //    Response.Buffer = true;
            //    Response.Charset = "";
            //    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //    Response.AddHeader("content-disposition", "attachment;filename= EmployeeReport.xlsx");

            //    using (MemoryStream MyMemoryStream = new MemoryStream())
            //    {
            //        wb.SaveAs(MyMemoryStream);
            //        MyMemoryStream.WriteTo(Response.OutputStream);
            //        Response.Flush();
            //        Response.End();
            //    }
            //}  

            return View(TableCPUEntry().ToList());
        }


        // GET: /CPUEntry/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cpuentry16 cpuentry16 = await db.cpuentry16.FindAsync(id);
            if (cpuentry16 == null)
            {
                return HttpNotFound();
            }
            return View(cpuentry16);
        }

        // GET: /CPUEntry/Create
        public ActionResult Create()
        {
            ddlLoad();
            return View();
        }

        // POST: /CPUEntry/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,asset_id,assetLocation_id,make_id,model_id,productnumber,serialnumber,assetowner,configuration,warranty,warrantyupto,remarks,lastedit,accessory_id,active")] cpuentry16 cpuentry16)
        {
            if (ModelState.IsValid)
            {
                db.cpuentry16.Add(cpuentry16);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ddlLoad();
            return View();
        }

        // GET: /CPUEntry/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cpuentry16 cpuentry16 = await db.cpuentry16.FindAsync(id);
            if (cpuentry16 == null)
            {
                return HttpNotFound();
            }
            ddlLoad();
            return View(cpuentry16);
        }

        // POST: /CPUEntry/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,asset_id,assetLocation_id,make_id,model_id,productnumber,serialnumber,assetowner,configuration,warranty,warrantyupto,remarks,lastedit,accessory_id,active")] cpuentry16 cpuentry16)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cpuentry16).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cpuentry16);
        }

        // GET: /CPUEntry/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cpuentry16 cpuentry16 = await db.cpuentry16.FindAsync(id);
            if (cpuentry16 == null)
            {
                return HttpNotFound();
            }
            return View(cpuentry16);
        }

        // POST: /CPUEntry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            cpuentry16 cpuentry16 = await db.cpuentry16.FindAsync(id);
            db.cpuentry16.Remove(cpuentry16);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public ActionResult Import()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Import(cpuEntyImport imp)
        {
            int count = 0;
            if (imp.getData!= null)
            {
                var table = imp.getData;
                if (table != null)
                {
                    string[] rows = table.Split('\n');
                    string[] cells;
                    for (int i = 0; i <= rows.Length - 1; i++)
                    {
                        cells = rows[i].Split('\t');
                        if (cells.Count() == 13)
                        {
                            bool Inset = ValidateandInsert(cells);
                            if (Inset)
                            {
                                count++;
                            }
                        }
                        //if (!Inset) break;
                    }
                }
            }
            ViewBag.Message = "No of Entry Placed is: " + count;
            return View();
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
        #region ddlLoad

        public void ddlLoad()
        {
            var m = db.mas_make.Where(i => i.accessoryId == 1).Select(i => new { i.id, i.make });
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


            List<SelectListItem> model = new List<SelectListItem>();
            var a = db.mas_model.Where(i => i.accessoryId == 1).Select(i => new { i.id, i.model });
            foreach (var l in a)
            {
                model.Add(new SelectListItem
                {
                    Text = l.model,
                    Value = l.id.ToString()
                });
            }
            ViewData["model"] = new SelectList(model, "Value", "Text", "");

            List<SelectListItem> classification = new List<SelectListItem>();
            var c = db.mas_classification.Select(i => new { i.id, i.classification });
            foreach (var l in c)
            {
                classification.Add(new SelectListItem
                {
                    Text = l.classification,
                    Value = l.id.ToString()
                });
            }
            ViewData["classification"] = new SelectList(classification, "Value", "Text", "");

            List<SelectListItem> owner = new List<SelectListItem>();
            var o = db.mas_owner.Select(i => new { i.id, i.owner });
            foreach (var l in o)
            {
                owner.Add(new SelectListItem
                {
                    Text = l.owner,
                    Value = l.id.ToString()
                });
            }
            ViewData["owner"] = new SelectList(owner, "Value", "Text", "");

            List<SelectListItem> warranty = new List<SelectListItem>();

            warranty.Add(new SelectListItem
            {
                Text = "Yes",
                Value = "True"
            });
            warranty.Add(new SelectListItem
            {
                Text = "No",
                Value = "False"
            });

            ViewData["warranty1"] = new SelectList(warranty, "Value", "Text", "");

            List<SelectListItem> active = new List<SelectListItem>();

            active.Add(new SelectListItem
            {
                Text = "Yes",
                Value = "True"
            });
            active.Add(new SelectListItem
            {
                Text = "No",
                Value = "False"
            });

            ViewData["active1"] = new SelectList(active, "Value", "Text", "");

        }
        #endregion
        public List<CPUEntryDisplay> TableCPUEntry()
        {
            CPUEntryDisplay c = new CPUEntryDisplay();
            string sSql = "select cpu.asset_id, cpu.assetLocation_id, ma.make, mo.model, cpu.productnumber," +
                            " serialnumber, o.owner, c.classification, cpu.configuration, case when cpu.warranty='true' then 'Yes' else 'No' end," +
                            " warrantyupto, remarks, case when cpu.active='True' then 'true' else 'False' end, cpu.id from cpuentry16 as cpu " +
                            " left join mas_make as ma on ma.id =cpu.make_id" +
                            " left join mas_model as mo on mo.id =cpu.model_id" +
                            " left join mas_owner as o on o.id =cpu.assetowner" +
                            " left join mas_classification as c on c.id =cpu.classification_id" +
                            " order by asset_id";

            string connstr = ConfigurationManager.ConnectionStrings["AssetsDB"].ConnectionString;
            SqlConnection cn = new SqlConnection(connstr);
            SqlCommand cmd = new SqlCommand(sSql, cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<CPUEntryDisplay> item = new List<CPUEntryDisplay>();

            while (dr.Read())
            {
                item.Add(
                    new CPUEntryDisplay
                    {

                        asset_id = dr[0].ToString(),
                        assetLocation_id = dr[1].ToString(),
                        make_id = dr[2].ToString(),
                        model_id = dr[3].ToString(),
                        productnumber = dr[4].ToString(),
                        serialnumber = dr[5].ToString(),
                        assetowner = dr[6].ToString(),
                        classification_id = dr[7].ToString(),
                        configuration = dr[8].ToString(),
                        warranty = dr[9].ToString(),
                        warrantyupto = dr[10].ToString(),
                        remarks = dr[11].ToString(),
                        active = dr[12].ToString(),
                        id = Convert.ToInt32(dr[13].ToString())

                    });
            }
            cn.Close();
            var CPU = from cp in item
                      orderby cp.asset_id
                      select cp;

            return item;
        }
        public bool ValidateandInsert(string[] cells)
        {
            cpuentry16 cpu = new cpuentry16();
            int makeId;
            bool flag = false;
            bool asset_Id = CheckDuplicate("cpuentry16", "asset_id", "S", cells[1].Trim());
            if (asset_Id)
            {

                return false;
            }
            else
            {
                cpu.asset_id = cells[1].Trim();
                flag = true;
            }
            bool assetLocation = CheckDuplicate("mas_assetlocation", "assetLocation", "S", cells[2].Trim());
            if (assetLocation)
            {
                cpu.assetLocation_id = cells[2].Trim();
                flag = true;
            }
            else
            {

                mas_assetLocation al = new mas_assetLocation();
                al.assetLocation = cells[2].Trim();
                al.active = true;
                db.mas_assetlocation.Add(al);
                db.SaveChanges();
                cpu.assetLocation_id = cells[2].Trim();
            }

            bool make = CheckDuplicate("mas_make", "make", "S", cells[6].Trim());
            if (make)
            {
                makeId = ReturnId("select Id from mas_make where make = '" + cells[6].Trim() + "'");
                cpu.make_id = makeId;

            }
            else
            {
                mas_make mak = new mas_make();
                mak.make = cells[6].Trim();
                mak.active = true;
                mak.accessoryId = 1;
                db.mas_make.Add(mak);
                db.SaveChanges();
                makeId = mak.id;
                cpu.make_id = makeId;
                flag = true;

            }
            bool model = CheckDupOnSQLString("select count(id) from mas_model where model='" + cells[3].Trim() + "' and make_id=" + makeId + "");
            if (model)
            {
                int modelId = ReturnId("select Id from mas_model where model= '" + cells[3].Trim() + "'");
                cpu.model_id = modelId;

            }
            else
            {
                mas_model mod = new mas_model();
                mod.accessoryId = 1;
                mod.make_id = makeId;
                mod.model = cells[3].Trim();
                mod.configuration = cells[7].Trim();
                mod.active = true;
                db.mas_model.Add(mod);
                db.SaveChanges();
                cpu.model_id = mod.id;
                flag = true;

            }



            cpu.serialnumber = cells[4].Trim();
            cpu.productnumber = cells[5].Trim();
            String config = cells[7].Replace("\"", "");
            cpu.configuration = config.Trim();

            bool owner = CheckDupOnSQLString("select count(id) from mas_owner where owner='" + cells[8].Trim() + "'");
            if (owner)
            {
                int ownerId = ReturnId("select Id from mas_owner where owner = '" + cells[8].Trim() + "'");
                cpu.assetowner = ownerId;
            }
            else
            {
                mas_owner own = new mas_owner();
                own.owner = cells[8].Trim();
                own.active = true;
                db.mas_owner.Add(own);
                db.SaveChanges();
                cpu.assetowner = own.id;
                flag = true;

            }

            bool classfication = CheckDupOnSQLString("select count(id) from mas_classification where classification='" + cells[9].Trim() + "'");
            if (classfication)
            {
                int classification = ReturnId("select Id from mas_classification where classification= '" + cells[9].Trim() + "'");
                cpu.classification_id = classification;


            }
            else
            {
                mas_classification clas = new mas_classification();
                clas.classification = cells[9].Trim();
                clas.active = true;
                db.mas_classification.Add(clas);
                db.SaveChanges();
                cpu.classification_id = clas.id;
                flag = true;

            }

            bool warty;
            if (cells[10].ToString() == "Yes")
            {
                warty = true;
            }
            else warty = false;

            cpu.warranty = warty;
            if (cells[11].Trim() != "NA")
            {
                cpu.warrantyupto = Convert.ToDateTime(cells[11].Trim());
            }
            cpu.remarks = cells[12].Trim();
            cpu.active = true;
            cpu.lastedit = DateTime.Now;
            db.cpuentry16.Add(cpu);

            db.SaveChanges();
            return flag;
        }



        #region IndexChanged
        [HttpPost]
        public ActionResult GetModel(int make)
        {
            var m = db.mas_model.Where(i => i.make_id == make).Select(i => new { i.id, i.model });
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var l in m)
            {
                list.Add(new SelectListItem
                {
                    Text = l.model,
                    Value = l.id.ToString()
                });
            }
            
            return Json(list, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult GetConfiguration(int id)
        {
            var m = db.mas_model.Where(i => i.id == id).Select(i => new { i.id, i.configuration });
            List<string> list = new List<string>();
            foreach (var l in m)
            {
                list.Add(l.configuration);
            }
            return Json(list);

        }

        [HttpPost]
        public bool ajaxCheckDuplicate(string cell)
        {
            var result = db.cpuentry16.Where(i => i.asset_id == cell).Select(i => i.asset_id);
            int res = result.Count();
            if (result.Count() > 0)
            {
                return true;
            }
            else return false;
        }

        #endregion


        public bool CheckDuplicate(string sTable, string sFieldName, string sFieldType, object sValue)
        {
            string Sql = "";
            // Warning!!! Optional parameters not supported

            switch (sFieldType)
            {
                case "S":
                    Sql = "Select count(id) from " + sTable + " where " + sFieldName + "='" + sValue + "'";
                    break;
                case "D":
                    Sql = "Select count(Id) from " + sTable + " where " + sFieldName + "='" + sValue + "'";
                    break;
                case "N":
                    Sql = "Select count(Id) from " + sTable + " where " + sFieldName + "=" + sValue + "";
                    break;
            }

            string connstr = ConfigurationManager.ConnectionStrings["AssetsDB"].ConnectionString;
            SqlConnection cn = new SqlConnection(connstr);
            SqlCommand cmd = new SqlCommand(Sql, cn);
            cn.Open();

            cmd.CommandText = Sql;
            if ((int)(cmd.ExecuteScalar()) > 0)
            {
                cn.Close();
                return true;
            }
            else
            {
                cn.Close();
                return false;
            }


            // TODO: Exit Function: Warning!!! Need to return the value

        }
        public bool CheckDupOnSQLString(string Sql)
        {

            string connstr = ConfigurationManager.ConnectionStrings["AssetsDB"].ConnectionString;

            SqlConnection cn = new SqlConnection(connstr);
            SqlCommand cmd = new SqlCommand(Sql, cn);
            cn.Open();

            cmd.CommandText = Sql;
            if ((int)(cmd.ExecuteScalar()) > 0)
            {
                cn.Close();
                return true;

            }
            else
            {
                cn.Close();
                return false;

            }
        }
        public int ReturnId(string Sql)
        {
            string connstr = ConfigurationManager.ConnectionStrings["AssetsDB"].ConnectionString;

            SqlConnection cn = new SqlConnection(connstr);
            SqlCommand cmd = new SqlCommand(Sql, cn);
            cn.Open();

            int RetId = (int)(cmd.ExecuteScalar());

            if (RetId > 0)
            {
                cn.Close();
                return RetId;

            }
            else
            {
                cn.Close();
                return RetId;

            }


        }

        #endregion
    }
}
