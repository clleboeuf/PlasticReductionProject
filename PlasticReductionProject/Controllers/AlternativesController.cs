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

        private LinkDbContext db = new LinkDbContext();

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

        public ActionResult FilAlternatives(int ProductID)
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

          //  var filteredProducts = db.Products.Where(others => others.Type == ProductID).ToList();

            var AltForType =  (from productID in db.Products
                               join AltProduct in db.Alternatives
                               on productID.Id equals AltProduct.ProductId
                               where productID.Id == ProductID
                               select productID.Description).ToList().FirstOrDefault().ToString();
            //.ToList().Distinct().ToList().FirstOrDefault().Description.ToString();

            return View(productName);
        }
    }
}