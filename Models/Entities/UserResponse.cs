using System;
using System.Collections.Generic;
using System.Web;

namespace CGCWRegistration.Models
{
    public class UserResponse
    {
        public int UserResponseID { get; set; } // primary key
        public int UserID { get; set; } // foreign key
        public int QuestionID { get; set; } // foreign key
        public int ResponseOptionID { get; set; } // foreign key

        // Navigation Properties
        public virtual User User { get; set; }
        public virtual Question Question { get; set; }
        public virtual ResponseOption ResponseOption { get; set; }
    }
}