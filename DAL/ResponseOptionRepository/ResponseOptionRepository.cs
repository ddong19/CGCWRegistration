using CGCWRegistration.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CGCWRegistration.DAL.ResponseOptionRepository
{
    public class ResponseOptionRepository : IResponseOptionRepository
    {
        private readonly RegistrationContext _context;

        public ResponseOptionRepository(RegistrationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ResponseOption>> GetResponseOptionsByQuestionIdAsync(int questionId)
        {
            return await _context.ResponseOptions
                                 .Where(ro => ro.QuestionID == questionId)
                                 .ToListAsync();
        }
    }
}