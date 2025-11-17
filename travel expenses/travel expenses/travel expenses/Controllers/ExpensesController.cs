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
            return Json(data);
        }


    }
}