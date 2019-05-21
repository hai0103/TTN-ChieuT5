using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTNhom.Models;
namespace TTN_DXQ_LCH_NTN.Areas.Admin.Controllers
{
    public class ManageUSController : Controller
    {
        // GET: Admin/ManageUS
        PetLandModel db = new PetLandModel();
        public ActionResult Index()
        {
            if(Session["Admin"] == null)
            {
                RedirectToAction("LoginAd", "LoginAd");
            }
            var lstUser = db.Customers.ToList();
            return View(lstUser);
        }

        public PartialViewResult AddModalPartial()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult AddModalPartial(Customer cus)
        {
            cus.CustomerName = Request.Form["name"];
            cus.Email = Request.Form["email"];
            cus.Address = Request.Form["address"];
            cus.IsAdmin = (Request.Form["admin"].Trim() == "Admin") ? 1 : (Request.Form["admin"].Trim() == "Moderator") ? 2 : 3;
            db.Customers.Add(cus);
            db.SaveChanges();
            return RedirectToAction("Index", "ManageUS");

        }

        public ActionResult validateEmail(string email)
        {
            var existUser = from us in db.Customers where (us.Email == email) select us;
            if (existUser != null)
            {
                ViewBag.alert = "Email is already exist";
            }
            return View();
        }
        //public bool validateEmail(string email)
        //{ 
        //    Customer customer = db.Customers.Where(c => c.Email == email).SingleOrDefault();
        //    if (customer != null)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        public PartialViewResult EditModalPartial(int ID)
        {
            Customer customer = db.Customers.SingleOrDefault(c => c.CustomerID == ID);

            return PartialView(customer);
        }

        [HttpPost]
        public ActionResult EditModalPartial(Customer customer)
        {
            var newCustomer = db.Customers.SingleOrDefault(c => c.CustomerID == customer.CustomerID);
            newCustomer.CustomerName = customer.CustomerName;
            newCustomer.Email = customer.Email;
            newCustomer.Address = customer.Address;
            newCustomer.IsAdmin = customer.IsAdmin = (Request.Form["admin"].Trim() == "Admin") ? 1 : (Request.Form["admin"].Trim() == "Moderator") ? 2 : 3;
            return View("Index", "ManageUS");
        }
        public ActionResult DeleteModalPartial(int ID)
        {
            Customer cus = db.Customers.SingleOrDefault(c => c.CustomerID == ID);
            db.Customers.Remove(cus);
            db.SaveChanges();
            return RedirectToAction("Index", "ManageUS");
        }
    }
}