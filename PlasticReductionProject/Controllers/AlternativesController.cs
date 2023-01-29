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

            List<Product> ProductList = db.Products.Where(i => i.Id == 1).ToList();

            return View(ProductList);
        }

        public ActionResult AlternativesDetails()
        {
            ViewBag.Page = "Alternatives";

            var productName = db.Alternatives.ToList().FirstOrDefault();

            ViewBag.Product = productName.ProductId;

            return View(db.Alternatives.ToList());
        }
    }
}