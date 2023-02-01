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

        private CalculatorResult cr
        { 
            get { return Session["CalculatorResults"] as CalculatorResult; }
            set { Session["CalculatorResults"] = value; }
        }
            
         
        // GET: Calculator
        public ActionResult Calculator()
        {
            
            cr = new CalculatorResult(5);
            List<int> usedRand = new List<int>();

            cr.Results.ForEach(x => {
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
            return View(cr.Results.First());
        }

        //post results
        [HttpPost]
        public ActionResult Calculator(FrequencySelection Usage)
        {
            this.cr.Results.ElementAt(this.cr.increment).Usage = Usage;
            this.cr.increment++;
            return View(this.cr.Results.ElementAt(this.cr.increment));
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