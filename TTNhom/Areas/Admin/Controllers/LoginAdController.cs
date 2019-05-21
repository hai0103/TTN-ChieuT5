using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTNhom.Models;

namespace TTNhom.Areas.Admin.Controllers
{
    public class LoginAdController : Controller
    {
        PetLandModel db = new PetLandModel();
        // GET: Admin/LoginAd
        public ActionResult LoginAd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginAd(Customer cus)
        {
            string us = Request.Form["username"];
            string mk = Request.Form["password"];
            if (ModelState.IsValid)
            {
                cus = db.Customers.SingleOrDefault(p => p.UserName == us.Trim() && p.Password == mk.Trim());
                if (cus != null)
                {
                    ViewBag.mess = "Successful";
                    Session["Admin"] = us;
                    return RedirectToAction("Index", "HomeAdmin");
                }
                else
                {
                    return RedirectToAction("LoginAd", "LoginAd");
                }
            }

            return View();
        }

        public ActionResult LogOut()
        {
            Session["Admin"] = null;
            return RedirectToAction("LoginAd", "LoginAd");
        }
    }
}