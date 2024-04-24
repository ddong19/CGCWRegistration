using CGCWRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGCWRegistration.Models.DTOs;

namespace CGCWRegistration.DAL.QuestionRepository
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<QuestionDTO>> GetAllQuestionsAsync();
        Task<Question> GetQuestionByIdAsync(int questionId);
    }
}
