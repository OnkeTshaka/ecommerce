using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using onlineStore101.Models;

namespace onlineStore101.Controllers
{
    public class AccessoryBrandsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AccessoryBrands
        public ActionResult Index()
        {
            return View(db.AccessoryBrands.ToList());
        }

        // GET: AccessoryBrands/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccessoryBrand accessoryBrand = db.AccessoryBrands.Find(id);
            if (accessoryBrand == null)
            {
                return HttpNotFound();
            }
            return View(accessoryBrand);
        }

        // GET: AccessoryBrands/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccessoryBrands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description")] AccessoryBrand accessoryBrand)
        {
            if (ModelState.IsValid)
            {
                db.AccessoryBrands.Add(accessoryBrand);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accessoryBrand);
        }

        // GET: AccessoryBrands/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccessoryBrand accessoryBrand = db.AccessoryBrands.Find(id);
            if (accessoryBrand == null)
            {
                return HttpNotFound();
            }
            return View(accessoryBrand);
        }

        // POST: AccessoryBrands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description")] AccessoryBrand accessoryBrand)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accessoryBrand).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accessoryBrand);
        }

        // GET: AccessoryBrands/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccessoryBrand accessoryBrand = db.AccessoryBrands.Find(id);
            if (accessoryBrand == null)
            {
                return HttpNotFound();
            }
            return View(accessoryBrand);
        }

        // POST: AccessoryBrands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AccessoryBrand accessoryBrand = db.AccessoryBrands.Find(id);
            db.AccessoryBrands.Remove(accessoryBrand);
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
