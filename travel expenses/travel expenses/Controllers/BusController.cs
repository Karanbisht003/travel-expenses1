using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using travel_expenses.Models;

namespace travel_expenses.Controllers
{
    public class BusController : Controller
    {
        
        travelMngSystemEntities db = new travelMngSystemEntities();

        // GET: Bus
        public ActionResult BusIndex()
        {
            return View();
        }
        public ActionResult GetBusData()
        {
            var data = db.BusExpenses.ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SaveBusdata( BusModel busExpens)
        {
            BusExpens b = new BusExpens();
            b.Id = busExpens.Id;
            b.TicketId = busExpens.TicketId;
            b.TripId = busExpens.TripId;
            b.DeparturePlace= busExpens.DeparturePlace;
            b.ArrivalPlace= busExpens.ArrivalPlace;
            b.Type= busExpens.Type;
            b.Time= busExpens.Time;
            b.Amount= busExpens.Amount;
            db.BusExpenses.Add(b);
            db.SaveChanges();
            return Json(b.Id, JsonRequestBehavior.AllowGet);
        }
        public ActionResult editBus (int Id)
        {
            var data = db.BusExpenses.Where(x => x.Id == Id).FirstOrDefault();
            return Json(data,JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult updatebus(int Id,BusModel b)
        {
            var data = db.BusExpenses.Where(x => x.Id == Id).FirstOrDefault();
            data.Id =b.Id ;
            data.TicketId= b.TicketId ;
            data.TripId= b.TripId ;
            data.DeparturePlace= b.DeparturePlace ;
            data.ArrivalPlace = b.ArrivalPlace ;
            data.Type= b.Type ;
            data.Type=b.Type ;
            data.Time= b.Time ;
            data.Amount= b.Amount ;
            db.SaveChanges();
            return Json(data.Id,JsonRequestBehavior.AllowGet);

        }
        public ActionResult deletebus(int Id) 
        {
       var data=db.BusExpenses.Where(x=>x.Id==Id).FirstOrDefault();
            db.BusExpenses. Remove(data);
            db.SaveChanges();
            return Json(data,JsonRequestBehavior.AllowGet);
    }
        }
}