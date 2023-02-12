using PlasticReductionProject.DAL;
using PlasticReductionProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlasticReductionProject.Controllers
{
    public class AlternativesController : Controller
    {

        private PlasticDbContext db = new PlasticDbContext();

        // GET: Alternatives
        public ActionResult Alternatives()
        {
            ViewBag.Page = "Alternatives";
         
            List<Product> ProductList = (List<Product>)(from productID in db.Products
                                                        join AltProduct in db.Alternatives
                                                        on productID.Id equals AltProduct.ProductId
                                                        select productID)
                                                        .ToList().Distinct().ToList();
            return View(ProductList);
        }

        public ActionResult AlternativesDetails(int ProductID)
        {
            ViewBag.Page = "Alternatives";
         /*   ViewBag.Product = (from productID in db.Products
                               join AltProduct in db.Alternatives
                               on productID.Id equals AltProduct.ProductId
                               where productID.Id == ProductID
                               select productID)
                               .ToList().Distinct().ToList().FirstOrDefault().Description.ToString();
         */
            var productName = db.Alternatives.Where(test => test.ProductId == ProductID).ToList();
            ViewBag.Product = (from productID in db.Products
                               join AltProduct in db.Alternatives
                               on productID.Id equals AltProduct.ProductId
                               where productID.Id == ProductID
                               select productID.Description).ToList().FirstOrDefault().ToString();
                                //.ToList().Distinct().ToList().FirstOrDefault().Description.ToString();

            return View(productName);
        }

        public ActionResult FilAlternatives(int ProductID, List<ProductResult> ResultsList, int blah)
        {
            ViewBag.Page = "Alternatives";

            List<ProductResult> ResultsTemp = (List<ProductResult>)TempData["tempResults"];
            var cResultsTemp = TempData["CalcResult"];

            List<int> currProducts = new List<int>();
            
                var getFullProductList = db.Products.Where(test => test.Type == ProductID).ToList();

                foreach(var item in getFullProductList)
                {
                      foreach(var product in ResultsTemp)
                    {
                        if(product.Product.Id == item.Id)
                        {
                            currProducts.Add(product.Product.Id);
                        }
                    }
                }
     //       }
            
            if(currProducts.Count > 0)
            {
                int translate = currProducts[0];
                var productName = db.Alternatives.Where(test => test.ProductId == translate).ToList();
                
                    for (int i = 1; i < currProducts.Count; i++)
                    {
                        int translate2 = currProducts[i];
                        var productName2 = db.Alternatives.Where(test => test.ProductId == translate2).ToList();
                        productName.AddRange(productName2);
                    }
                var prod = "";
                if (productName.Count > 0)
                {
                    var prodItem = productName.FirstOrDefault().ProductId;

                    var prodName = db.Products.Where(sub => sub.Id == prodItem).ToList();
                    prod = prodName.FirstOrDefault().Description.ToString();
                }
                ViewBag.SubProduct = prod;
                    if(productName.Count == 0)
                {
                    ViewBag.AltText = "The products you were asked about don't have good alternatives";
                    ViewBag.AltText2 = "Make sure you recycle what you use.";
                }
                else
                {

                }
                    return View(productName.ToList());
            }


            ViewBag.AltText = "The products you were asked about don't have good alternatives";
            ViewBag.AltText2 = "Make sure you recycle what you use.";

            var AltForType =  (from productID in db.Products
                               join AltProduct in db.Alternatives
                               on productID.Id equals AltProduct.ProductId
                               where productID.Id == ProductID
                               select productID.Description).ToList().FirstOrDefault().ToString();
            //.ToList().Distinct().ToList().FirstOrDefault().Description.ToString();

            return View();
        }
    }
}