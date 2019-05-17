using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTNhom.Models;

namespace TTNhom.Controllers
{
    public class BlogController : Controller
    {

        PetLandModel db = new PetLandModel();
        // GET: Blog
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Blog()
        {
            var blog = from b in db.Blogs select b;
            return View(blog.Take(3).ToList());
        }
        public ActionResult BlogInfoPartial()
        {
            var lstBlog = db.Blogs.Where(a => a.New == 1).ToList();
            return PartialView(lstBlog);
        }
        public ActionResult BlogDetail(int BlogID)
        {
            Blog blog = db.Blogs.SingleOrDefault(p => p.BlogID == BlogID);
            if (blog == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(blog);
        }
    }
}