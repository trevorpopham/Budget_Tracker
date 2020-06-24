using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Budget_Tracker.Models
{
    public class TransactionEditViewModel
    {
        public ApplicationUser User { get; set; }
        public Household Household { get; set; }
        public Transaction Transaction { get; set; }
        public Budget Budget { get; set; }
    }
}