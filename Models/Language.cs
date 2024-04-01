using System;
using System.Collections.Generic;
using System.Web;

namespace CGCWRegistration.Models
{
    public class Language
    {
        public int LanguageID { get; set; } // primary key
        public string LanguageName { get; set; }

        // Navigation Property
        public virtual ICollection<UserLanguage> UserLanguages { get; set; }
    }
}