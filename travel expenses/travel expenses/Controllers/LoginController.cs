using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using travel_expenses.Models;

namespace travel_expenses.Controllers
{
    public class LoginController : Controller
    {
        travelMngSystemEntities db=new travelMngSystemEntities();
        // GET: Login
        public ActionResult LoginIndex()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string Name , string Password)
        {
            var data1 = db.Users.ToList();

            var data = db.Users.Where(x => x.Name == Name && x.Passwords == Password).FirstOrDefault();

            if (data != null)
            {
                
                Session["Name"] = data.Name;
                Session[SessionConstant.UserId] = data.Id;
                Session[SessionConstant.EmpId] = data.EmpId;
                return RedirectToAction("UserIndex", "User");
            }
            else
            {
                return View();
            }           

        }

       

    }
}