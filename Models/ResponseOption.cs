using System;
using System.Collections.Generic;
using System.Web;

namespace CGCWRegistration.Models
{
    public class ResponseOption
    {
        public int ResponseOptionID { get; set; } // primary key
        public int QuestionID { get; set; } // foreign key 
        public string ResponseOptionText { get; set;}

        // Navigation properties
        public virtual Question Question { get; set;}
        public virtual ICollection<UserResponse> UserResponses { get; set; }
    }
}