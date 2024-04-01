using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CGCWRegistration.Models
{
    public class UserLanguage
    {
        public int UserLanguageID { get; set; } // primary key
        public int UserID { get; set; } // foreign key
        public int LanguageID { get; set; } // foreign key

        // Navigation Properties
        public virtual User User { get; set; }
        public virtual Language Language { get; set; }
    }
}