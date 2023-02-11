using Microsoft.Ajax.Utilities;
using Owin;
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
        private PlasticDbContext db = new PlasticDbContext();

        private CalculatorResult cr
        {
            get { return Session["CalculatorResults"] as CalculatorResult; }
            set { Session["CalculatorResults"] = value; }
        }
        private int QuestionCount = 5;

        // GET: Calculator
        public ActionResult Calculator(int? questions)
        {
            List<int> usedRand = new List<int>();
            var randomProducts = new List<Product>();
            int productCount = db.Products.Count();

            if (questions > 0 && questions < productCount)
            {
                QuestionCount = (int)questions;
            }
            cr = new CalculatorResult(QuestionCount);

            while (randomProducts.Count() < QuestionCount)
            {
                var rand = Randomiser.RandomNumber(1, productCount);
                if (!usedRand.Contains(rand))
                {
                    usedRand.Add(rand);
                    var test = db.Products.Find(rand);
                    //if (test.Type == 3 || test.Type == 7 || test.Type == 2)
                    //{
                    randomProducts.Add(test);
                    //}
                }
            }

            int index = -1;
            cr.Results.ForEach(x =>
            {
                index++;
                x.Product = randomProducts[index];
            });


            ViewBag.QuestionCounter = "Question " + (this.cr.increment + 1).ToString() + " of " + this.cr.Results.Count().ToString();
            ViewBag.Page = "Calculator";
            return View(cr.Results.First());
        }

        //post results
        [HttpPost]
        public ActionResult Calculator(ProductResult result)
        {
            ProductResult toSave = this.cr.Results.ElementAt(this.cr.increment);
            PlasticType plasticType = db.PlasticTypes.Find(toSave.Product.Type);
            Product product = toSave.Product;
            toSave.Usage = result.Usage;
            toSave.PeriodUsed = result.PeriodUsed;
            toSave.PeriodRecycled = result.PeriodRecycled;
            toSave.AmountUsed = result.AmountUsed;
            toSave.AmountRecycled = result.AmountRecycled;
            result.Product = product;

            PlasticScore IfFound = this.cr.PlasticScores.Where(x => x.Name.Equals(plasticType.Acronym)).FirstOrDefault();
            var score = calculateResultForProduct(result);
            var average = product.averageUtilisation;
            if (IfFound != null)
            {
                IfFound.Score += score;
                IfFound.Average += average;
            }
            else
            {
                this.cr.PlasticScores.Add(new PlasticScore(plasticType.Acronym, score, average));
            }

            switch (product.Type)
            {
                case 1:
                    cr.PPScore += score;
                    cr.PPAvg += average;
                    break;
                case 2:
                    cr.PPAScore += score;
                    cr.PPAAvg += average;
                    break;
                case 3:
                    cr.HDPEScore += score;
                    cr.HDPEAvg += average;
                    break;
                case 4:
                    cr.LDPEScore += score;
                    cr.LDPEAvg += average;
                    break;
                case 5:
                    cr.PVCScore += score;
                    cr.PVCAvg += average;
                    break;
                case 6:
                    cr.PETScore += score;
                    cr.PETAvg += average;
                    break;
                case 7:
                    cr.PSScore += score;
                    cr.PSAvg += average;
                    break;
                default:
                    cr.OtherScore += score;
                    cr.OtherAvg += average;
                    break;
            }
            this.cr.increment++;

            ViewBag.QuestionCounter = "Question " + (this.cr.increment + 1).ToString() + " of " + this.cr.Results.Count().ToString();

            if (this.cr.increment == this.cr.Results.Count)
            {

                return RedirectToAction("Report");
            }

            return View(this.cr.Results.ElementAt(this.cr.increment));
        }

        private double calculateResultForProduct(ProductResult result)
        {
            //needs to be put in a function
            var usedMultiplier = 1;
            // var recycledMultiplier = 1;
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
            //switch (result.PeriodRecycled.ToString())
            //{
            //    case "Day":
            //        recycledMultiplier = 365;
            //        break;
            //    case "Week":
            //        recycledMultiplier = 52;
            //        break;
            //    case "Month":
            //        recycledMultiplier = 12;
            //        break;
            //    default:
            //        break;
            //}

            //double recycleRate = db.PlasticTypes.Find(result.Product.Type).Recyclability;
            //double score = result.AmountUsed * usedMultiplier * result.Product.Weight - result.AmountRecycled * recycledMultiplier * result.Product.Weight;
            double score = result.AmountUsed * usedMultiplier * result.Product.Weight;
            return score;

        }


        // GET: Report
        public ActionResult Report()
        {

            ViewBag.Page = "Report";

            var totalScore = this.cr.PlasticScores.Sum(x => x.Score);
            var totalAverage = this.cr.PlasticScores.Sum(x => x.Average);

            var compScore = totalScore / totalAverage;

            List<Badge> badges = db.Badges.ToList();

            int turtles = 1;

            switch (compScore)
            {
                case var _ when compScore < 0.01:
                    turtles = 5;
                    break;
                case var _ when compScore < 0.05:
                    turtles = 4;
                    break;
                case var _ when compScore < 0.1:
                    turtles = 3;
                    break;
                case var _ when compScore < 0.3:
                    turtles = 2;
                    break;
                default:
                    break;
            }

            ViewBag.Comment = badges.ElementAt(turtles).Comment.ToString();
            ViewBag.Image = badges.ElementAt(turtles).BadgeUrl.ToString();

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


            List<PlasticType> PlasticTypeList = (List<PlasticType>)(from plastic_Id in db.PlasticTypes
                                                                    select plastic_Id)
                                                        .ToList().Distinct().ToList();

            return View(PlasticTypeList);
        }


    }
}