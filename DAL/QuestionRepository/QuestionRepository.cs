using CGCWRegistration.Models;
using CGCWRegistration.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CGCWRegistration.DAL.QuestionRepository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly RegistrationContext _context;

        public QuestionRepository(RegistrationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<QuestionDTO>> GetAllQuestionsAsync()
        {
            return await _context.Questions
                                 .Include(q => q.ResponseOptions)
                                 .Select(q => new QuestionDTO
                                 {
                                     Id = q.QuestionID,
                                     Question = q.QuestionText,
                                     ResponseOptions = q.ResponseOptions.Select(ro => new ResponseOptionDTO
                                     {
                                         Id = ro.ResponseOptionID,
                                         Response = ro.ResponseOptionText
                                     }).ToList()
                                 }).ToListAsync();
        }

        public async Task<Question> GetQuestionByIdAsync(int questionId)
        {
            return await _context.Questions
                                 .Include(q => q.ResponseOptions)
                                 .FirstOrDefaultAsync(q => q.QuestionID == questionId);
        }
    }
}