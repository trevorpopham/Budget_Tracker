using Budget_Tracker.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Budget_Tracker.Models
{
    public class DashboardViewModel
    {
        public Household Household { get; set; }
        public ChartData ChartData { get; set; }
        public decimal SpentToday { get; set; }
        public decimal SpentWeek { get; set; }
        public decimal SpentMonth { get; set; }
    }
}