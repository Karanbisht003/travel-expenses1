using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace travel_expenses.Controllers
{
    public class TravelController : Controller
    {
        // GET: Travel``
        public ActionResult TravelIndex()
        {
            return View();
        }
    }
}