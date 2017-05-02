using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using AssetsMVC.Models;
using Assets_MVC_.Models;

namespace AssetsMVC.Controllers
{
    //[RequireHttps]
    public class HomeController : Controller
    {
        private AssetsDBContext db = new AssetsDBContext();

        public ActionResult Index()
        {

            var chart = ChartItems().ToList();
            ViewData["CpuCount"] = db.cpuentry16.Count<cpuentry16>();
            ViewData["Monitorcount"] = db.monitorentry16.Count<monitorentry16>();
            ViewData["Mousecount"] = db.mouseentry16.Count<mouseentry16>();
            ViewData["Keyboardcount"] = db.keyboardentry16.Count<keyboardentry16>();
    
            return View(chart);
        }
        public ActionResult Charts()
        {
            var chart = ChartItems().ToList();
            return PartialView("Charts",chart);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public List<Charts> ChartItems()
        {

            string sSql = "select 'CPUs', count(id) as TotalEntries from CPUEntry16" +
                            " Union all" +
                           " Select 'Monitor', count(id) as TotalEntries from MonitorEntry16" +
                           " Union all" +
                           " Select 'Mouse', count(id) as TotalEntries from MouseEntry16" +
                           " Union all" +
                           " Select 'Keyboard', count(id) as TotalEntries from KeyboardEntry16";
                           
            string connstr = ConfigurationManager.ConnectionStrings["AssetsDB"].ConnectionString;
            SqlConnection cn = new SqlConnection(connstr);
            SqlCommand cmd = new SqlCommand(sSql, cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<Charts> item = new List<Charts>();

            while (dr.Read())
            {
                item.Add(
                    new Charts
                    {
                        accessory = dr[0].ToString(),
                        totalentries = Convert.ToInt32(dr[1].ToString())

                    });
            }
            cn.Close();

            return item;
        }
        [HttpGet]
        public JsonResult HighChartAjaxMethod()
        {
            List<Summary> item = new List<Summary>();
            string sSql = "select 'CPUs', count(id) as TotalEntries from CPUEntry16" +
                           " Union all" +
                          " Select 'Monitor', count(id) as TotalEntries from MonitorEntry16" +
                          " Union all" +
                          " Select 'Mouse', count(id) as TotalEntries from MouseEntry16" +
                          " Union all" +
                          " Select 'Keyboard', count(id) as TotalEntries from KeyboardEntry16";


           using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AssetsDB"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sSql))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            item.Add(new Summary
                            {
                                label = sdr[0].ToString(),
                                Y = Convert.ToInt32(sdr[1].ToString())
                            });

                        }
                    }

                    con.Close();
                }
            }

            return Json(item.ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}