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
            ViewBag.QuestionCounter = "Question " + (this.cr.increment + 1).ToString() + " of " + this.cr.Results.Count().ToString();
            ViewBag.Page = "Calculator";
            return View(cr.Results.First());
        }

        //post results
        [HttpPost]
        public ActionResult Calculator(ProductResult result)
        {
            this.cr.Results.ElementAt(this.cr.increment).Usage = result.Usage;
            this.cr.Results.ElementAt(this.cr.increment).PeriodUsed = result.PeriodUsed;
            this.cr.Results.ElementAt(this.cr.increment).PeriodRecycled = result.PeriodRecycled;
            this.cr.Results.ElementAt(this.cr.increment).AmountUsed = result.AmountUsed;
            this.cr.Results.ElementAt(this.cr.increment).AmountRecycled = result.AmountRecycled;
            
            
            //needs to be put in a function
            var usedMultiplier = 1;
            var recycledMultiplier = 1;
            switch (result.PeriodUsed.ToString())
            {
                case "Day":
                    usedMultiplier = 365;
                    break;
                case "Week":
                    usedMultiplier = 52;
                    break;
                case "Month":
                    usedMultiplier = 12;
                    break;
                default:
                    break;
            }
            switch (result.PeriodRecycled.ToString())
            {
                case "Day":
                    recycledMultiplier = 365;
                    break;
                case "Week":
                    recycledMultiplier = 52;
                    break;
                case "Month":
                    recycledMultiplier = 12;
                    break;
                default:
                    break;
            }

           // double recycleRate = db.PlasticTypes.Find(Id == 1).;

            double score = result.AmountUsed * usedMultiplier - result.AmountRecycled*recycledMultiplier;
            
            switch (this.cr.Results.ElementAt(this.cr.increment).Product.Type)
            {
                case 1 :
                    cr.PPScore += score;
                    break;
                case 2:
                    cr.PPAScore += score;
                    break;
                case 3:
                    cr.HDPEScore += score;
                    break;
                case 4:
                    cr.LDPEScore += score;
                    break;
                case 5:
                    cr.PVCScore += score;
                    break;
                case 6:
                    cr.PETScore += score;
                    break;
                case 7:
                    cr.PSScore += score;
                    break;
                default:
                    cr.OtherScore += score;
                    break;
            }
            this.cr.increment++;
            
            ViewBag.QuestionCounter = "Question " + (this.cr.increment + 1).ToString() + " of " + this.cr.Results.Count().ToString();

            if (this.cr.increment == 5)
            {
              //  db.SaveChanges();
               return RedirectToAction("Report");
            }

            

            return View(this.cr.Results.ElementAt(this.cr.increment));
        }


        // GET: Report
        public ActionResult Report()
        {

            /*if (HttpContext.Request.Cookies["UserCookie"] == null) {   
                var SessionCookie = new HttpCookie("UserCookie");
                SessionCookie.Values.Add(Session.SessionID.ToString(), "SessionId");
                Response.Cookies.Add(SessionCookie);
                HttpCookie cookie = HttpContext.Request.Cookies["UserCookie"];
                ViewBag.SessionCookie = cookie.Values[0];
            }
            else 
            {
                var SessionCookie = new HttpCookie(Session.SessionID.ToString());
                HttpCookie oldCookie = HttpContext.Request.Cookies["UserCookie"];
                string oldSessionId = oldCookie.Values["SessionId"].ToString();
                string currSessionId = Session.SessionID.ToString();
                string combinedSessionID = oldSessionId + "," + currSessionId; 
                oldCookie.Values.Add("SessionId",combinedSessionID);
                //SessionCookie.Values.Add("SessionIDs", "SessionId");
                HttpCookie cookie = HttpContext.Request.Cookies["UserCookie"];
                ViewBag.SessionCookie = oldCookie.Values["SessionId"];
                var counter = 0;
                ViewBag.CookieKey = "";
                foreach (var value in cookie.Values)
                {
                    ViewBag.CookieKey += value.ToString();
                   
                    counter += 1;
                } 
                //ViewBag.CookieKey = cookie.Value;
            }*/


            ViewBag.Page = "Report";
            return View(this.cr);
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