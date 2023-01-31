using PlasticReductionProject.DAL;
using PlasticReductionProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlasticReductionProject.Views.Calculator
{
    public class CalculatorController : Controller
    {
        private LinkDbContext db = new LinkDbContext();

        // GET: Calculator
        public ActionResult Calculator()
        {
            var results = new CalculatorResult(5);
            var anotherResults = new CalculatorResult(5);

            ViewBag.Page = "Calculator";
            return View();
        }

        // GET: Report
        public ActionResult Report()
        {
            ViewBag.Page = "Report";
            return View();
        }

        public ActionResult Products()
        {
            ViewBag.Page = "Products";
            

            List<Product> ProductList = (List<Product>)(from productID in db.Products
                                                        select productID)
                                                        .ToList().Distinct().ToList();

            return View(ProductList);
        }

        public ActionResult PlasticTypes()
        {
            ViewBag.Page = "PlasticTypes";


            List<PlasticTypes> PlasticTypeList = (List<PlasticTypes>)(from plastic_Id in db.PlasticTypes
                                                                      select plastic_Id)
                                                        .ToList().Distinct().ToList();

            return View(PlasticTypeList);
        }
    }
}