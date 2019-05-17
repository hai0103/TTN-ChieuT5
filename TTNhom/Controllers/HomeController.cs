using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTNhom.Models;

namespace TTNhom.Controllers
{
    public class HomeController : Controller
    {
        PetLandModel db = new PetLandModel();
        // GET: User
        public ActionResult Index()
        {
            var list = db.Products.Where(p => p.New == 1).Take(8).ToList();
            return View(list);
        }
        public PartialViewResult BreadcrumbsPartial()
        {
            return PartialView();
        }
    }
}