using CGCWRegistration.DAL.AgeRangeRepository;
using CGCWRegistration.DAL.UserRepository;
using CGCWRegistration.Models;
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
        // using our DAL to get age ranges
        public async Task<IEnumerable<AgeRange>> GetAllAgeRangesAsync()
        {
            return await _ageRangeRepository.GetAllAgeRangesAsync();
        }

        public async Task RegisterUserAsync(User user)
        {
            // Include logic to handle user registration, like setting RegistrationDate
            user.RegistrationDate = DateTime.Now;
            await _userRepository.AddUserAsync(user);
        }
    }
}