using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGCWRegistration.Models.ViewModels;
using CGCWRegistration.Models;


namespace CGCWRegistration.BLL.UsersService
{   
    public interface IUsersService
    {
        Task<User> GetUserByIdAsync(int id);
        Task DeleteUserByIdAsync(int id);
        Task<List<UsersViewModel>> ListUsersAsync();
    }
}
