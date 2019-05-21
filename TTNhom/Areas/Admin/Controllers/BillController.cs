using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTNhom.Models;
namespace TTNhom.Areas.Admin.Controllers
{
    public class BillController : Controller
    {
        PetLandModel db = new PetLandModel();
        // GET: Admin/Bill
        public ActionResult Index()
        {
            var lstOrder = db.Orders.ToList();
            return View(lstOrder);
        }

        public ActionResult Edit(int Id)
        {
            Order order = db.Orders.SingleOrDefault(p => p.OrderID == Id);
            return View(order);
        }

        [HttpPost]
        public ActionResult Edit(Order order)
        {
            Order newOrder = db.Orders.SingleOrDefault(p => p.OrderID == order.OrderID);
            newOrder.Paid = order.Paid = (Request.Form["paid"] == "1") ? 1 : 2;
            newOrder.TransferStatus = order.TransferStatus = (Request.Form["status"] == "0") ? 0 : (Request.Form["status"] == "1") ? 1 : 2;
            newOrder.OrderDate = order.OrderDate;
            db.SaveChanges();
            return View();
        }

        public ActionResult Details(int Id)
        {
            var detail = (from foo in db.Products
                          from bar in db.OrderDetails
                          where foo.ProductID == bar.ProductID && bar.OrderID == Id

                          select new OrderDetailViewModel()
                          {
                              Product = foo,
                              OrderDetail = bar
                          });

            //OrderDetail orderDetail = db.OrderDetails.SingleOrDefault(p => p.OrderID == Id);
            return View(detail);
        }
    }
}