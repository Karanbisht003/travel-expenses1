using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using travel_expenses.Models;

namespace travel_expenses.Controllers
{
    public class OtherController : Controller
    {
        travelMngSystemEntities db = new travelMngSystemEntities();
        // GET: Other
        public ActionResult otherIndex()
        {
            return View();
        }
        public ActionResult GetOtherExpenses()
        {
            var data = db.OtherExpenses.ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SaveOtherExpenses(otherExpenses1 o)
        {
            OtherExpens ot = new OtherExpens();
            ot.Id = o.Id;
            ot.TripId = o.TripId;
            ot.DeparturePlace = o.DeparturePlace;
            ot.ArrivalPlace = o.ArrivalPlace;
            ot.Type = o.Type;
            ot.Time = o.Time;
            ot.Amount = o.Amount;
            db.OtherExpenses.Add(ot);
            db.SaveChanges();
            return Json(ot.Id, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditOtherexpenses(int Id)
        {
            var data=db.OtherExpenses.Where(x=>x.Id == Id).FirstOrDefault();
            return Json(data, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult UpdateOtherExpenses(int Id,otherExpenses1 o)

        {
            var other = db.OtherExpenses.Where(x => x.Id == Id).FirstOrDefault();
            other.Id = o.Id;
            other.TripId = o.TripId;
            other.DeparturePlace = o.DeparturePlace;
            other.ArrivalPlace = o.ArrivalPlace;
            other.Type = o.Type;
            other.Time = o.Time;
            other.Amount = o.Amount;
           
            db.SaveChanges();
            return Json(other.Id, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteOtherexpenses(int Id)
        {
            var data=db.OtherExpenses.Where(x=>x.Id==Id).FirstOrDefault();
            db.OtherExpenses.Remove(data);
            db.SaveChanges();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}