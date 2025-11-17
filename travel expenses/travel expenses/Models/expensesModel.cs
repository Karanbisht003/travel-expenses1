using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace travel_expenses.Models
{
    public class expensesModel
    {
   
            public int ExpensesId { get; set; }
            public DateTime FromDate { get; set; }
            public DateTime ToDate { get; set; }
            public string Address { get; set; }
            public string CompanyName { get; set; }
            public string AdvancePayment { get; set; }
            public string Puspose { get; set; }
        
    }
}