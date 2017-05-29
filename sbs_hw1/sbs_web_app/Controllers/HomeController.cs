using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
using sbs_web_app.Models;
using sbs_hw1;

namespace sbs_web_app.Controllers
{
    public class HomeController : Controller
    {
        sbs_hw1.GameStats stats;
        public ActionResult Index()
        {
            stats = new sbs_hw1.GameStats();
            stats.getAllStats();
            Stats[] arr = new Stats[stats.listStats.Count];
            stats.listStats.CopyTo(arr);
            ViewBag.listStats = arr;
            ViewBag.avgWin = stats.getAvgWin().ToString("0.00");

            return View();
        }

        
    }
}