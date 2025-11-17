using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using travel_expenses.Models;

namespace travel_expenses.Controllers
{
    public class TrainController : Controller
    {
        travelMngSystemEntities db = new travelMngSystemEntities();
        // GET: Train
        public ActionResult TrainIndex()
        {
            return View();
        }
        public ActionResult GetTrainData()
        {
            var data = db.TrainExpenses.ToList();
            return Json(data,JsonRequestBehavior.AllowGet);
        }
        public ActionResult SaveTrainData(TrainModel T)
        {
            TrainExpens te = new TrainExpens();
            te.Id = T.Id;
            te.TicketId = T.TicketId;
            te.TripId = T.TripId;
            te.DeparturePlace = T.DeparturePlace;
            te.ArrivalPlace = T.ArrivalPlace;
            te.Type = T.Type;
            te.Time = T.Time;
            te.Amount = T.Amount;
            db.TrainExpenses.Add(te);
            db.SaveChanges();
            return Json(te.Id, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditTrainData(int Id)
        {
            var data = db.TrainExpenses.Where(x => x.Id == Id).FirstOrDefault();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpdateTrainData(int Id, TrainModel t)
        {
            var data = db.TrainExpenses.Where(x => x.Id == Id).FirstOrDefault();
            data.Id = t.Id;
            data.TicketId = t.TicketId;
            data.TripId = t.TripId;
            data.DeparturePlace = t.DeparturePlace;
            data.ArrivalPlace = t.ArrivalPlace;
            data.Type = t.Type;
            data.Time = t.Time;
            data.Amount = t.Amount;
            db.SaveChanges();
            return Json(data.Id, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteTrainData(int Id)
        {
            var data = db.TrainExpenses.Where(x => x.Id == Id).FirstOrDefault();
            db.TrainExpenses.Remove(data);
            db.SaveChanges();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

     }
}