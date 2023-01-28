using PlasticReductionProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlasticReductionProject.Controllers
{
    public class ProjectsController : Controller
    {
        private LinkDbContext db = new LinkDbContext(); 

        // GET: Projects
        public ActionResult Projects()
        {
            ViewBag.Page = "Projects";
            return View(db.Projects.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}