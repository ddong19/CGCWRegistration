using CGCWRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCWRegistration.DAL.UserResponseRepository
{
    public interface IUserResponseRepository
    {
        Task<IEnumerable<UserResponse>> GetAllAgeUsersResponseAsync();
        Task AddUserResponseAsync(UserResponse userResponse);
    }
}
