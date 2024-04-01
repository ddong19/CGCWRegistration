using System;
using System.Collections.Generic;
using System.Web;

namespace CGCWRegistration.Models
{
    public class Question
    {
        public int QuestionID { get; set; } // primary key
        public string QuestionText { get; set; }

        // Navigation Properties
        public virtual ICollection<ResponseOption> ResponseOptions { get; set; }
    }
}