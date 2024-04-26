using CGCWRegistration.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CGCWRegistration.Models.DTOs
{
    public class UserDTO
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
        public List<int> SelectedLanguageIds { get; set; }
        public List<QuestionResponse> Responses { get; set; }

        public UserDTO()
        {
            SelectedLanguageIds = new List<int>();
            Responses = new List<QuestionResponse>();
        }
    }
}