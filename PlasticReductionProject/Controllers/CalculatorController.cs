using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlasticReductionProject.Views.Calculator
{
    public class CalculatorController : Controller
    {
        // GET: Calculator
        public ActionResult Calculator()
        {
            ViewBag.Page = "Calculator";
            return View();
        }
    }
}