using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTNhom.Models;
using PagedList;
using PagedList.Mvc;
namespace TTNhom.Controllers
{
    public class StoreController : Controller
    {
        PetLandModel db = new PetLandModel();
        // GET: Store

        public ActionResult Shop()
        {
            var lstCat = db.CategoryOfProducts.ToList();
            return View(lstCat);
        }

        public PartialViewResult Product(int? categoryOfProductID, int? pageIndex)
        {
            var items = new List<Product>();
            int _pageIndex = pageIndex ?? 1;
            if (categoryOfProductID == null)
            {
                items = db.Products.ToList();
            }
            else
            {
                items = (from pr in db.Products
                         where pr.CategoryOfProductID == categoryOfProductID
                         select pr).ToList();
            }

            return PartialView(items.OrderBy(x => x.CategoryOfProductID).ToPagedList(_pageIndex, 6));
        }

        public ActionResult ProductDetail(int ProductID)
        {
            Product product = db.Products.SingleOrDefault(p => p.ProductID == ProductID);
            return View(product);

        }
    }
}