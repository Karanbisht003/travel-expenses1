using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using travel_expenses.Models;

namespace travel_expenses.Controllers
{
    public class UserController : Controller
    {
        travelMngSystemEntities db=new travelMngSystemEntities ();
        // GET: User
        public ActionResult UserIndex()
        {
            return View();
        }
        public ActionResult GetUser()
        {
            var data = db.Users.ToList();
            return Json(data,JsonRequestBehavior.AllowGet);
        }
        public ActionResult SaveUser(UserModel1 T )
        { 
            User u=new User();
            u.Id = T.Id;
            u.Name= T.Name;
            u.EmpId = T.EmpId;
            u.UserId= T.UserId;
            u.Passwords= T.Passwords;
            u.Status= T.Status;
            db.Users.Add(u);
            db.SaveChanges();
            return Json(T.Id, JsonRequestBehavior.AllowGet);

        }
        public ActionResult EditUser(int Id)
        {
            var data = db.Users.Where(x => x.Id == Id).FirstOrDefault();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult updateUser(  int Id,string Name,string EmpId,string UserId,string Passwords,string Status )
        {
            var data = db.Users.Where(x => x.Id == Id).FirstOrDefault();

            data.Id = Id;
            data.Name =Name;
            data.EmpId =EmpId;
            data.UserId = UserId;
            data.Passwords = Passwords;
            data.Status = Status;
            db.SaveChanges();
            return Json(data.Id,JsonRequestBehavior.AllowGet);
        }
    }
}