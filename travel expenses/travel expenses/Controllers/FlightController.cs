using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using travel_expenses.Models;

namespace travel_expenses.Controllers
{
    public class FlightController : Controller
    {
        travelMngSystemEntities db = new travelMngSystemEntities();

        // GET: Flight
        public ActionResult FlighhIndex()
        {
            return View();
        }
        public ActionResult FlightGet()
        {
            var data = db.flightExpenses.ToList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SaveFlight(FlightModel f)
        {
            flightExpens fe=new flightExpens();
            fe.Id = f.Id;
            fe.TicketId = f.TicketId;
            fe.TripId = f.TripId;
            fe.DeparturePlace = f.DeparturePlace;
            fe.ArrivalPlace = f.ArrivalPlace;
            fe.Type = f.Type;
            fe.Time=f.Time;
            fe.Amount = f.Amount;
            db.flightExpenses.Add(fe);
            db.SaveChanges();   
            return Json(fe.Id, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditFlight(int Id)
        {
            var data = db.flightExpenses.Where(x => x.Id == Id).FirstOrDefault();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpdateFlight(int Id, FlightModel f)
        {
            var data = db.flightExpenses.Where(x => x.Id == Id).FirstOrDefault();
            data.Id = f.Id;
            data.TicketId = f.TicketId;
            data.TripId = f.TripId;
            data.DeparturePlace = f.DeparturePlace;
            data.ArrivalPlace = f.ArrivalPlace;
            data.Type = f.Type;
            data.Time = f.Time;
            data.Amount = f.Amount;
            db.SaveChanges();
            return Json(data.Id, JsonRequestBehavior.AllowGet);
        }
        public ActionResult deleteFlight(int Id)
        {
            var data = db.flightExpenses.Where(x => x.Id == Id).FirstOrDefault();
            db.flightExpenses.Remove(data);
            db.SaveChanges();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}