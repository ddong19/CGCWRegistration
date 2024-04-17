using CGCWRegistration.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CGCWRegistration.DAL.UserResponseRepository
{
    public class UserResponseRepository: IUserResponseRepository
    {
        private readonly RegistrationContext _context;
        public UserResponseRepository(RegistrationContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UserResponse>> GetAllAgeUsersResponseAsync()
        {
            return await _context.UserResponses.ToListAsync();
        }
        public async Task AddUserResponseAsync(UserResponse userResponse)
        {
            if (userResponse == null)
            {
                throw new ArgumentNullException(nameof(userResponse));
            }
            _context.UserResponses.Add(userResponse);
            await _context.SaveChangesAsync();
        }
    }
}