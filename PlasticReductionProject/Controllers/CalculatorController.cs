using Microsoft.Ajax.Utilities;
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
            List<int> usedRand = new List<int>();

            results.Results.ForEach(x => {
                int counter = 0;
                int productCount = db.Products.Count();
                while(counter < 5)
                {
                var rand = Randomiser.RandomNumber(1, productCount);
                  if(!usedRand.Contains(rand))
                    {
                        usedRand.Add(rand);
                        var test = db.Products.Find(rand);
                        x.Product = test;
                        usedRand.Add(rand);
                        counter += 1;
                    }             
                }
            });

            ViewBag.Page = "Calculator";
            return View(results.Results.First());
        }

        //post results
        [HttpPost]
        public ActionResult Calculator(FrequencySelection Usage)
        {
            var results = new CalculatorResult(5);
            List<int> usedRand = new List<int>();

            results.Results.ForEach(x => {
                int counter = 0;
                int productCount = db.Products.Count();
                while (counter < 5)
                {
                    var rand = Randomiser.RandomNumber(1, productCount);
                    if (!usedRand.Contains(rand))
                    {
                        usedRand.Add(rand);
                        var test = db.Products.Find(rand);
                        x.Product = test;
                        usedRand.Add(rand);
                        counter += 1;
                    }
                }
            });

            ViewBag.Page = "Calculator";
            return View(results.Results.First());
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