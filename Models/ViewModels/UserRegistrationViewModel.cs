using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CGCWRegistration.Models.DTOs;
using System.ComponentModel.DataAnnotations;

namespace CGCWRegistration.Models.ViewModels
{
    public class UserRegistrationViewModel
    {
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        public string ChineseName { get; set; }
        [Required(ErrorMessage = "Sex is required")]
        public string Sex { get; set; }
        public string Occupation { get; set; }
        [Required(ErrorMessage = "Age Range is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select an age range")]
        public int AgeRangeID { get; set; }
        [Required(ErrorMessage = "Phone Number is required")]
        [Phone(ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Not a valid email address")]
        public string Email { get; set; }
        public string Address { get; set; }
        public string IntroducedBy { get; set; }
        public string ExistingMember { get; set; }
        public IEnumerable<AgeRangeDTO> AgeRanges { get; set; } // To populate a dropdown in the form

        // New properties for language and question/response handling
        public List<LanguageViewModel> Languages { get; set; }
        public List<int> SelectedLanguageIds { get; set; } // IDs of selected languages

        public List<QuestionViewModel> Questions { get; set; }
        public List<QuestionResponse> Responses { get; set; }
        public UserRegistrationViewModel()
        {
            Languages = new List<LanguageViewModel>();
            SelectedLanguageIds = new List<int>();
            Questions = new List<QuestionViewModel>();
            Responses = new List<QuestionResponse>();
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

    public class QuestionResponse
    {
        public int QuestionId { get; set; }
        public int ResponseId { get; set; }
    }

}