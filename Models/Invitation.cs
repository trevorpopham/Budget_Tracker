using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Budget_Tracker.Models
{
    public class Invitation
    {
        public int Id { get; set; }
        public bool IsValid { get; set; }
        public DateTime Created { get; set; }
        public DateTime TimeToLive { get; set; }
        public string RecipientEmail { get; set; }
        public Guid Code { get; set; }

        public int HouseholdId { get; set; }
        public virtual Household Household { get; set; }
    }
}