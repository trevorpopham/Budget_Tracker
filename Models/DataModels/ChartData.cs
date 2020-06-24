using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Budget_Tracker.Models.DataModels
{
    public class ChartData
    {
        public List<string> Labels {get; set;}
        public List<decimal> Data { get; set; }
    }
}