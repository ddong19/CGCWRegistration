using CGCWRegistration.DAL.AgeRangeRepository;
using CGCWRegistration.DAL.UserRepository;
using CGCWRegistration.Models;
using CGCWRegistration.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CGCWRegistration.BLL
{
    public class RegistrationService: IRegistrationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAgeRangeRepository _ageRangeRepository;

        public RegistrationService(IUserRepository userRepository, IAgeRangeRepository ageRangeRepository)
        {
            _userRepository = userRepository;
            _ageRangeRepository = ageRangeRepository;
        }
        public async Task<IEnumerable<AgeRange>> GetRangesAsync()
        {
            return await _ageRangeRepository.GetAllAgeRangesAsync();
        }

        public async Task<UserRegistrationViewModel> PrepareRegistrationViewModelAsync()
        {
            var ageRanges = await _ageRangeRepository.GetAllAgeRangesAsync();
            var viewModel = new UserRegistrationViewModel
            {
                AgeRanges = ageRanges
            };
            return viewModel;
        }

        public async Task RegisterUserAsync(UserRegistrationViewModel model)
        {
            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                ChineseName = model.ChineseName,
                Sex = model.Sex,
                Occupation = model.Occupation,
                AgeRangeID = model.AgeRangeID,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                Address = model.Address,
                IntroducedBy = model.IntroducedBy,
                ExistingMember = model.ExistingMember,
                RegistrationDate = DateTime.Now,
            };

            await _userRepository.AddUserAsync(user);
        }
    }
}