using System;
using System.Collections.Generic;
using System.Web;

namespace CGCWRegistration.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ChineseName { get; set; }
        public string Sex { get; set; }
        public string Occupation { get; set; }
        public int AgeRangeID { get; set; } // foreign key
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string IntroducedBy { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string ExistingMember { get; set; }
        
        // Navigation Properties
        public virtual AgeRange AgeRange { get; set; }
        public virtual ICollection<UserResponse> UserResponses { get; set; }
        public virtual ICollection<UserLanguage> UserLanguages { get; set; }
    }
}