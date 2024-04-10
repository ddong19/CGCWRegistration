using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CGCWRegistration.Models.ViewModels
{
    public class UserRegistrationViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ChineseName { get; set; }
        public string Sex { get; set; }
        public string Occupation { get; set; }
        public int AgeRangeID { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string IntroducedBy { get; set; }
        public string ExistingMember { get; set; }

        public IEnumerable<AgeRange> AgeRanges { get; set; } // To populate a dropdown in the form
    }

}