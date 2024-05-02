using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CGCWRegistration.Models.ViewModels
{
    public class UsersViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ChineseName { get; set; }
        public string Sex { get; set; }
        public string Occupation { get; set; }
        public string AgeRange { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string IntroducedBy { get; set; }
        public string ExistingMember { get; set; }
        public List<string> Languages { get; set; }
        public List<QuestionResponseViewModel> Responses { get; set; }
    }

    public class QuestionResponseViewModel
    {
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public string Response { get; set; }
    }

    public class UsersPageViewModel
    {
        public List<UsersViewModel> Users { get; set; }
        public List<string> Questions { get; set; }
    }
}