using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlasticReductionProject.Controllers
{
    public class TrackerController : Controller
    {
        // GET: Tracker
        public ActionResult Tracker()
        {
            ViewBag.Page = "Tracker";
            return View();
        }
    }
}