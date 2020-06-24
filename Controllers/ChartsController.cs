using Budget_Tracker.Models;
using Budget_Tracker.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Budget_Tracker.Controllers
{
    public class ChartsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Charts
        public PartialViewResult LoadChartData(int householdId)
        {
            var household = db.Households.Find(householdId);
            var baseAmount = household.StartAmount;

            var data = new ChartData();
            for (int i = 1; i < 31; i++)
            {
                data.Labels.Add($"{i}");
            }
            
            for (int i = 1; i < 31; i++)
            {
                data.Data.Add(baseAmount);

            }
            return PartialView("", data);
            
        }
    }
}