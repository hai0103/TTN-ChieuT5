using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TTNhom.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        // GET: Admin/HomeAdmin
        public ActionResult Index()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("LoginAd", "LoginAd");
            }
            return View();
        }
    }
}