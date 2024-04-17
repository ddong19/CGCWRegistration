using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGCWRegistration.Models;


namespace CGCWRegistration.DAL.UserLanguageRepository
{
    public interface IUserLanguageRepository
    {
        Task<IEnumerable<UserLanguage>> GetAllUsersLanguageAsync();
        Task AddUserLanguageAsync(UserLanguage userLanguage);
    }
}
