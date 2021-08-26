using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using onlineStore101.Models;
using Microsoft.AspNet.Identity;

namespace onlineStore101.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.AccessoryBrand).Include(p => p.Category).Include(p => p.City).Include(p => p.Country).Include(p => p.Currency).Include(p => p.Seller).Include(p => p.State);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.AccessoryBrandID = new SelectList(db.AccessoryBrands, "ID", "Name");
            ViewBag.catId = new SelectList(db.Categories, "ID", "Name");
            ViewBag.CityID = new SelectList(db.Cities, "ID", "Name");
            ViewBag.CountryID = new SelectList(db.Countries, "ID", "Name");
            ViewBag.CurrencyID = new SelectList(db.Currencies, "ID", "Name");
            ViewBag.StateID = new SelectList(db.States, "ID", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Description,Picture,Quantity,Price,Slug,PostingTime,OperatingSystem,Ram,Processor,HardDisk,Condition,catId,CurrencyID,CityID,StateID,CountryID,AccessoryBrandID,SellerID")] Product product, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {
                // Configuration for users
                string CurrentUserName = User.Identity.GetUserName();
                product.SellerID = db.Users.Where(s => s.UserName == CurrentUserName).FirstOrDefault().Id;
                // Configuration for images
                if (ImageFile != null)
                {
                    product.Picture = new byte[ImageFile.ContentLength];
                    ImageFile.InputStream.Read(product.Picture, 0, ImageFile.ContentLength);
                }
                product.Slug = product.Title.Replace(' ', '-');
                product.PostingTime = DateTime.Now;

                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccessoryBrandID = new SelectList(db.AccessoryBrands, "ID", "Name", product.AccessoryBrandID);
            ViewBag.catId = new SelectList(db.Categories, "ID", "Name", product.catId);
            ViewBag.CityID = new SelectList(db.Cities, "ID", "Name", product.CityID);
            ViewBag.CountryID = new SelectList(db.Countries, "ID", "Name", product.CountryID);
            ViewBag.CurrencyID = new SelectList(db.Currencies, "ID", "Name", product.CurrencyID);
            ViewBag.StateID = new SelectList(db.States, "ID", "Name", product.StateID);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccessoryBrandID = new SelectList(db.AccessoryBrands, "ID", "Name", product.AccessoryBrandID);
            ViewBag.catId = new SelectList(db.Categories, "ID", "Name", product.catId);
            ViewBag.CityID = new SelectList(db.Cities, "ID", "Name", product.CityID);
            ViewBag.CountryID = new SelectList(db.Countries, "ID", "Name", product.CountryID);
            ViewBag.CurrencyID = new SelectList(db.Currencies, "ID", "Name", product.CurrencyID);
            ViewBag.StateID = new SelectList(db.States, "ID", "Name", product.StateID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Description,Picture,Quantity,Price,Slug,PostingTime,OperatingSystem,Ram,Processor,HardDisk,Condition,catId,CurrencyID,CityID,StateID,CountryID,AccessoryBrandID,SellerID")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccessoryBrandID = new SelectList(db.AccessoryBrands, "ID", "Name", product.AccessoryBrandID);
            ViewBag.catId = new SelectList(db.Categories, "ID", "Name", product.catId);
            ViewBag.CityID = new SelectList(db.Cities, "ID", "Name", product.CityID);
            ViewBag.CountryID = new SelectList(db.Countries, "ID", "Name", product.CountryID);
            ViewBag.CurrencyID = new SelectList(db.Currencies, "ID", "Name", product.CurrencyID);
            ViewBag.StateID = new SelectList(db.States, "ID", "Name", product.StateID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
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
