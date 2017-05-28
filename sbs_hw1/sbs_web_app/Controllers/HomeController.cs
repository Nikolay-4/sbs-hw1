using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
using sbs_web_app.Models;

namespace sbs_web_app.Controllers
{
    public class HomeController : Controller
    {
        GameStats stats;
        public ActionResult Index()
        {
            stats = new GameStats();
            stats.getAllStats();
            Stats[] arr = new Stats[stats.listStats.Count];
            stats.listStats.CopyTo(arr);
            ViewBag.listStats = arr;
            ViewBag.avgWin = stats.getAvgWin().ToString("0.00");

            return View();
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
    }
}