using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CGCWRegistration.Models.DTOs
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public List<ResponseOptionDTO> ResponseOptions { get; set; }
    }
}