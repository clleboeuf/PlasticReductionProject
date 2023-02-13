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
        private int QuestionCount = 10;

        private List<ProductResult> productsUsed = new List<ProductResult>();




        // GET: Calculator
        public ActionResult Intro()
        {

            ViewBag.Page = "Intro";
            List<int> usedRand = new List<int>();
            var characterFacts = new List<(Character character, PlasticFact fact)>();
            List<Character> characters = db.Characters.ToList();
            foreach (Character ch in characters)
            {
                var unused = false;
                while (!unused)
                {
                    var rand = Randomiser.RandomNumber(1, db.PlasticFacts.Count());
                    unused = !usedRand.Contains(rand);
                    if (unused)
                    {
                        usedRand.Add(rand);
                        var tuple = (character: ch, fact: db.PlasticFacts.Find(rand));
                        characterFacts.Add(tuple);
                    }
                }
            }
            ViewBag.Characters = characterFacts;
            return View();
         }

        //post results

        public ActionResult Calculator(int? questions)
        {

            cr = new CalculatorResult(5);

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

                    randomProducts.Add(test);
                }
            }

            int index = -1;
            cr.Results.ForEach(x =>
            {
                index++;
                x.Product = randomProducts[index];
            });
            var characterFacts = new List<(Character character, PlasticFact fact)>();          
            var randFact = Randomiser.RandomNumber(1, db.PlasticFacts.Count());
            var randCharacter = Randomiser.RandomNumber(1, db.Characters.Count());
            var tuple = (character: db.Characters.Find(randCharacter), fact: db.PlasticFacts.Find(randFact));
            characterFacts.Add(tuple);

   
            ViewBag.Characters = characterFacts;
            ViewBag.QuestionCounter = "Question " + (this.cr.Increment + 1).ToString() + " of " + this.cr.Results.Count().ToString();
            ViewBag.Page = "Calculator";
            return View(cr.Results.First());
        }

        //post results
        [HttpPost]

        public ActionResult Calculator(ProductResult result)
        {
            ProductResult toSave = this.cr.Results.ElementAt(this.cr.Increment);
            PlasticType plasticType = db.PlasticTypes.Find(toSave.Product.Type);
            Product product = toSave.Product;
            toSave.Usage = result.Usage;
            toSave.PeriodUsed = result.PeriodUsed;
            toSave.PeriodRecycled = result.PeriodRecycled;
            toSave.AmountUsed = result.AmountUsed;
            toSave.AmountRecycled = result.AmountRecycled;
            result.Product = product;

            PlasticScore IfFound = this.cr.PlasticScores.Where(x => x.Name.Equals(plasticType.Acronym)).FirstOrDefault();
            var score = CalculateResultForProduct(result);
            var average = product.averageUtilisation;
            if (IfFound != null)
            {
                IfFound.Score += score;
                IfFound.Average += average;
            }
            else
            {
                this.cr.PlasticScores.Add(new PlasticScore(plasticType.Acronym, score, average, plasticType));
            }

            this.cr.Increment++;

            ViewBag.QuestionCounter = "Question " + (this.cr.Increment + 1).ToString() + " of " + this.cr.Results.Count().ToString();

            if (this.cr.Increment == this.cr.Results.Count)
            {

                return RedirectToAction("Report");
            }

            var characterFacts = new List<(Character character, PlasticFact fact)>();
            var randFact = Randomiser.RandomNumber(1, db.PlasticFacts.Count());
            var randCharacter = Randomiser.RandomNumber(1, db.Characters.Count());
            var tuple = (character: db.Characters.Find(randCharacter), fact: db.PlasticFacts.Find(randFact));
            characterFacts.Add(tuple);


            ViewBag.Characters = characterFacts;

            return View(this.cr.Results.ElementAt(this.cr.Increment));
        }

        private double CalculateResultForProduct(ProductResult result)
        {

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


        public ActionResult altButton(int ProductId)
        {
            
            var newResults = new List<ProductResult>();
            TempData["tempResults"] = this.cr.Results.ToList();
            TempData["CalcResult"] = this.cr;
            return RedirectToAction("FilAlternatives", "Alternatives", new { ProductID = ProductId, ResultsList = TempData["tempResults"], blah = 5});
      //      return View();
        }

        // GET: Report
        public ActionResult Report()
        {

           
            ViewBag.Page = "Report";

            var totalScore = this.cr.PlasticScores.Sum(x => x.Score);
            var totalAverage = this.cr.PlasticScores.Sum(x => x.Average);

            var compScore = totalScore / totalAverage;


            List<double> AllScores = this.cr.PlasticScores.Select(x => x.Score).ToList();

            List<double> AllAverages = this.cr.PlasticScores.Select(x => x.Average).ToList();

            List<double> Rankings = this.cr.PlasticScores.Select(x => x.Score/x.Average).ToList();


            ViewBag.LowestProduct = this.cr.FindLowestPlasticScore().Name.ToString();
            ViewBag.HighestProduct = this.cr.FindHighestPlasticScore().Name.ToString();


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