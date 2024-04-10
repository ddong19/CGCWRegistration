using CGCWRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCWRegistration.DAL.UserRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAgeUsersAsync();
        Task AddUserAsync(User user);
    }
}
