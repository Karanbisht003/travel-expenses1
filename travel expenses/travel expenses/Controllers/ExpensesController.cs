using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using travel_expenses.Models;

namespace travel_expenses.Controllers
{
    public class ExpensesController : Controller
    {
        travelMngSystemEntities db = new travelMngSystemEntities();

        // GET: Expenses
        public ActionResult ExpensesIndex()
        {
            return View();
        }
        public ActionResult GetExpenses()
        {
            var data = db.Expenses.ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
     
        public ActionResult SaveExpeense(expensesModel E)
        {
            Expens e=new Expens();
            e.ExpensesId = E.ExpensesId;
            e.FromDate = E.FromDate;
            e.ToDate = E.ToDate;
            e.Address = E.Address;
            e.CompanyName = E.CompanyName;
            e.AdvancePayment = E.AdvancePayment;
            e.Puspose = E.Puspose;
            db.Expenses.Add(e);
            db.SaveChanges();
            return Json(E.ExpensesId,JsonRequestBehavior.AllowGet);

        }
        public ActionResult EditExpenses(int ExpensesId)
        {
            var data=db.Expenses.Where(x=>x.ExpensesId==ExpensesId).FirstOrDefault();
            return Json(data,JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
       public ActionResult updateExpenses(int ExpensesId, DateTime FromDate, DateTime ToDate, string Address, string CompanyName, string AdvancePayment, string Puspose)
        {
            var data = db.Expenses.Where(x => x.ExpensesId == ExpensesId).FirstOrDefault();
            
          data. ExpensesId =ExpensesId;
            data.FromDate = FromDate;
            data.ToDate = ToDate;
           data. Address = Address;
            data.CompanyName = CompanyName;
            data.AdvancePayment = AdvancePayment;
            data.Puspose = Puspose;
            db.SaveChanges();
            return Json(data.ExpensesId, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteExpenses(int ExpensesId )
        {
            var data = db.Expenses.Where(x => x.ExpensesId == ExpensesId).FirstOrDefault();
            db.Expenses.Remove(data);
            db.SaveChanges();
            return Json(data, JsonRequestBehavior.AllowGet);
        }


    }
}