using onlineStore101.Models;
using onlineStore101.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace onlineStore101.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index(string search, string category)
        {
            //var categories = db.Products.Select(x => new CategoryViewModel { Name = x.Category.Name }).Distinct().ToList();
            ViewBag.selectedCategory = category;
            var products = (dynamic)null;
            if (string.IsNullOrEmpty(category) && string.IsNullOrEmpty(search))
            {
                products = db.Products.ToList();

            }
            else if (!string.IsNullOrEmpty(category) && !string.IsNullOrEmpty(search))
            {
                products = db.Products
                    .Where(p => p.Category.Name.Equals(category) && p.Title.Contains(search))
                    .ToList();
            }
            else
            {
                products = db.Products
                    .Where(p => p.Category.Name.Equals(category) || p.Title.Contains(search))
                    .ToList();
            }
            HomeViewModel LBDV = new HomeViewModel
            {
                Product = db.Products.OrderByDescending(c => c.ID).Take(3),
                Category = db.Categories.OrderByDescending(c => c.ID).ToList()
            };
            return View(LBDV);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}