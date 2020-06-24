﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Budget_Tracker.Models
{
    public class TransactionCreateViewModel
    {
        public ApplicationUser User { get; set; }
        public Household Household { get; set; }
        public Budget Budget { get; set; }
        public string DateTime { get; set; }
    }
}