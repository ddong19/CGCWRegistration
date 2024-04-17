using CGCWRegistration.Models;
using CGCWRegistration.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCWRegistration.BLL
{
    public interface IRegistrationService
    {
        Task<UserRegistrationViewModel> PrepareRegistrationViewModelAsync();
        Task RegisterUserAsync(UserRegistrationViewModel model);
    }
}
