using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace travel_expenses.Models
{
    public class otherExpenses1
    {
        public int Id { get; set; }
        public string TripId { get; set; }
        public string DeparturePlace { get; set; }
        public string ArrivalPlace { get; set; }
        public string Type { get; set; }
        public string Time { get; set; }
        public string Amount { get; set; }

    }
}