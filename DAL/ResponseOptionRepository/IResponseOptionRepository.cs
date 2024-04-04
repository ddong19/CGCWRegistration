using CGCWRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCWRegistration.DAL.ResponseOptionRepository
{
    public interface IResponseOptionRepository
    {
        Task<IEnumerable<ResponseOption>> GetResponseOptionsByQuestionIdAsync(int questionId);
    }
}
