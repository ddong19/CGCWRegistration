using CGCWRegistration.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CGCWRegistration.DAL.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly RegistrationContext _context;
        public UserRepository(RegistrationContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetAllAgeUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task AddUserAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}