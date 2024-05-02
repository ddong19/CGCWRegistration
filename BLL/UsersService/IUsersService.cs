using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGCWRegistration.Models.ViewModels;


namespace CGCWRegistration.BLL.UsersService
{
    public interface IUsersService
    {
        Task<List<UsersViewModel>> PrepareUsersViewModelAsync();
    }
}
