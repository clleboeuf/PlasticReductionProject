using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlasticReductionProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //need to have if statement if returning
            ViewBag.Welcome = "Welcome to My Plastic Footprint Tracker.  Please start with step 1 below.";
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