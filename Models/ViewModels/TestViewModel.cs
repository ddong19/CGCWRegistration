using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CGCWRegistration.Models.DTOs;

namespace CGCWRegistration.Models.ViewModels
{
    public class TestViewModel
    {
        public IEnumerable<LanguageDTO> Languages { get; set; }
        public IEnumerable<AgeRangeDTO> AgeRanges { get; set; }
        public IEnumerable<QuestionDTO> Questions { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}