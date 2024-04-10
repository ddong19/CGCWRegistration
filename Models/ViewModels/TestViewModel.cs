using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CGCWRegistration.Models.ViewModels
{
    public class TestViewModel
    {
        public IEnumerable<Language> Languages { get; set; }
        public IEnumerable<AgeRange> AgeRanges { get; set; }
        public IEnumerable<Question> Questions { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}