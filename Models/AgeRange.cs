using System;
using System.Collections.Generic;
using System.Web;

namespace CGCWRegistration.Models
{
    public class AgeRange
    {
        public int AgeRangeID { get; set; } // primary key
        public string Range { get; set; }

        // Navigation Property
        public virtual ICollection<User> Users { get; set; }
    }
}