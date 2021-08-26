using onlineStore101.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace onlineStore101.Controllers
{
    public class AJAXController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: AJAX
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FillStates(int Country)
        {
            var states = db.States.ToList().Where(s => s.CountryID == Country);

            return Json(states, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FillCities(int State)
        {
            var cities = db.Cities.ToList().Where(s => s.StateID == State);

            return Json(cities, JsonRequestBehavior.AllowGet);
        }
    }
}