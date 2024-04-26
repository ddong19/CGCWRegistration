using CGCWRegistration.DAL.AgeRangeRepository;
using CGCWRegistration.DAL.LanguageRepository;
using CGCWRegistration.DAL.QuestionRepository;
using CGCWRegistration.DAL.UserRepository;
using CGCWRegistration.DAL.UserLanguageRepository;
using CGCWRegistration.DAL.UserResponseRepository;
using CGCWRegistration.Models;
using CGCWRegistration.Models.ViewModels;
using CGCWRegistration.Models.DTOs;
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
        private readonly ILanguageRepository _languageRepository;
        private readonly IQuestionRepository _questionRepository;

        public RegistrationService(IUserRepository userRepository, IAgeRangeRepository ageRangeRepository,
                                   ILanguageRepository languageRepository, IQuestionRepository questionRepository)
        {
            _userRepository = userRepository;
            _ageRangeRepository = ageRangeRepository;
            _languageRepository = languageRepository;
            _questionRepository = questionRepository;
        }

        public async Task<UserRegistrationViewModel> PrepareRegistrationViewModelAsync()
        {
            var ageRanges = await _ageRangeRepository.GetAllAgeRangesAsync();
            var languages = await _languageRepository.GetAllLanguagesAsync();
            var questions = await _questionRepository.GetAllQuestionsAsync();

            var viewModel = new UserRegistrationViewModel
            {
                AgeRanges = ageRanges,
                Languages = languages.Select(lang => new LanguageViewModel { Id = lang.Id, Name = lang.Name }).ToList(),
                Questions = questions.Select(q => new QuestionViewModel { QuestionId = q.Id, Text = q.Question, ResponseOptions = q.ResponseOptions.Select(ro => new ResponseOptionViewModel { Id = ro.Id, Text = ro.Response }).ToList() }).ToList(),
            };
            return viewModel;
        }

        public async Task RegisterUserAsync(UserRegistrationViewModel model)
        {
            // business object verification (error in form will return error to frontend)
            var userDTO = new UserDTO // use a user DTO
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
                SelectedLanguageIds = model.SelectedLanguageIds,
                Responses = model.Responses.Select(r => new QuestionResponse
                {
                    QuestionId = r.QuestionId,
                    ResponseId = r.ResponseId
                }).ToList()
            };

            // Save language and responses within the database acccess, with the user (all or nothing)
            await _userRepository.AddUserAsync(userDTO);
        }

        // user data in Vue.js --> bind to UserRegistrationViewModel --> RegistrationController --> RegistrationService (BLL) --> RegistrationRepository (DAL) (saves to DB)
    }
}