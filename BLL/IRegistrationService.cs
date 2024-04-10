using CGCWRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCWRegistration.BLL
{
    public interface IRegistrationService
    {
        Task<IEnumerable<AgeRange>> GetAllAgeRangesAsync();
        Task RegisterUserAsync(User user);
    }
}
