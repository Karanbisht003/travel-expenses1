using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace travel_expenses.Models
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var data = httpContext.Session["Name"];
            if (data != null)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
    }
}