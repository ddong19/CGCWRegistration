using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        // New properties for language and question/response handling
        public List<LanguageViewModel> Languages { get; set; }
        public List<int> SelectedLanguageIds { get; set; } // IDs of selected languages

        public List<QuestionViewModel> Questions { get; set; }
        public Dictionary<int, int> Responses { get; set; } // Key: QuestionId, Value: SelectedResponseOptionId

        public UserRegistrationViewModel()
        {
            Languages = new List<LanguageViewModel>();
            SelectedLanguageIds = new List<int>();
            Questions = new List<QuestionViewModel>();
            Responses = new Dictionary<int, int>();
        }
    }
    public class LanguageViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class QuestionViewModel
    {
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public List<ResponseOptionViewModel> ResponseOptions { get; set; }

        public QuestionViewModel()
        {
            ResponseOptions = new List<ResponseOptionViewModel>();
        }
    }

    public class ResponseOptionViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}