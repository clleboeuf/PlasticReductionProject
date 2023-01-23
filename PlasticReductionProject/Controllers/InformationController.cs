using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlasticReductionProject.Controllers
{
    public class InformationController : Controller
    {
        // GET: Information
        public ActionResult Information()
        {
            ViewBag.Page = "Information";
            return View();
        }
    }
}