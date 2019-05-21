using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTNhom.Models;
using PagedList.Mvc;
using PagedList;
namespace TTNhom.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        PetLandModel db = new PetLandModel();
        // GET: Admin/Product
        public ActionResult ListProduct(int? pageIndex)
        {
            var items = db.Products.ToList();
            int _pageIndex = pageIndex ?? 1;
            return PartialView(items.OrderBy(x => x.ProductID).ToPagedList(_pageIndex, 5));
        }


        public ActionResult EditProduct(int id)
        {
            SetViewBag();
            Product product = (from pr in db.Products select pr).SingleOrDefault(p => p.ProductID == id);
            return View(product);
        }

        [HttpPost]
        public ActionResult EditProduct(Product product, HttpPostedFileBase file)
        {
            var newProduct = (from pr in db.Products select pr).SingleOrDefault(p => p.ProductID == product.ProductID);
            newProduct.ProductName = product.ProductName;
            newProduct.Image = Request.Form["img"];
            newProduct.Price = product.Price;
            newProduct.New = product.New;
            newProduct.Total = product.Total;
            newProduct.Description = product.Description;
            newProduct.CategoryOfProductID = product.CategoryOfProductID;
            db.SaveChanges();

            return RedirectToAction("ListProduct", "Product");
        }

        //Thêm mới sản phẩm
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        public void SetViewBag(int? selectedId = null)
        {
            var dao = new CategoryViewModel();
            ViewBag.CategoryOfProductID = new SelectList(dao.ListAll(), "CategoryOfProductID", "CategoryOfProductName", selectedId);
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            product.ProductName = Request.Form["name"];
            product.Price = Convert.ToDecimal(Request.Form["price"]);
            product.Image = Request.Form["img"];
            product.New = Convert.ToInt16(Request.Form["new"]);
            product.Total = Convert.ToInt16(Request.Form["total"]);
            //product.CategoryOfProductID = Convert.ToInt16(Request.Form["category"]);
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("ListProduct", "Product");
        }

        //Xóa sản phẩm
        public ActionResult Delete(int id)
        {
            var pr = (from p in db.Products select p).SingleOrDefault(c => c.ProductID == id);
            db.Products.Remove(pr);
            db.SaveChanges();
            return RedirectToAction("ListProduct", "Product");
        }
    }
}