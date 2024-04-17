using CGCWRegistration.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CGCWRegistration.DAL.UserLanguageRepository
{
    public class UserLanguageRepository: IUserLanguageRepository
    {
        private readonly RegistrationContext _context;
        public UserLanguageRepository(RegistrationContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UserLanguage>> GetAllUsersLanguageAsync()
        {
            return await _context.UserLanguages.ToListAsync();
        }
        public async Task AddUserLanguageAsync(UserLanguage userLanguage)
        {
            if (userLanguage == null)
            {
                throw new ArgumentNullException(nameof(userLanguage));
            }
            _context.UserLanguages.Add(userLanguage);
            await _context.SaveChangesAsync();
        }
    }
}