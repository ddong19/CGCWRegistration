using CGCWRegistration.DAL.AgeRangeRepository;
using CGCWRegistration.DAL.LanguageRepository;
using CGCWRegistration.DAL.QuestionRepository;
using CGCWRegistration.DAL.UserRepository;
using CGCWRegistration.DAL.UserLanguageRepository;
using CGCWRegistration.DAL.UserResponseRepository;
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
        private readonly ILanguageRepository _languageRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IUserLanguageRepository _userlanguageRepository;
        private readonly IUserResponseRepository _userresponseRepository;

        public RegistrationService(IUserRepository userRepository, IAgeRangeRepository ageRangeRepository,
                                   ILanguageRepository languageRepository, IQuestionRepository questionRepository,
                                   IUserLanguageRepository userLanguageRepository, IUserResponseRepository userResponseRepository)
        {
            _userRepository = userRepository;
            _ageRangeRepository = ageRangeRepository;
            _languageRepository = languageRepository;
            _questionRepository = questionRepository;
            _userlanguageRepository = userLanguageRepository;
            _userresponseRepository = userResponseRepository;
        }

        public async Task<UserRegistrationViewModel> PrepareRegistrationViewModelAsync()
        {
            var ageRanges = await _ageRangeRepository.GetAllAgeRangesAsync();
            var languages = await _languageRepository.GetAllLanguagesAsync();
            var questions = await _questionRepository.GetAllQuestionsAsync();

            var viewModel = new UserRegistrationViewModel
            {
                AgeRanges = ageRanges,
                Languages = languages.Select(lang => new LanguageViewModel { Id = lang.LanguageID, Name = lang.LanguageName }).ToList(),
                Questions = questions.Select(q => new QuestionViewModel { QuestionId = q.QuestionID, Text = q.QuestionText, ResponseOptions = q.ResponseOptions.Select(ro => new ResponseOptionViewModel { Id = ro.ResponseOptionID, Text = ro.ResponseOptionText }).ToList() }).ToList(),
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

            foreach (var languageID in model.SelectedLanguageIds)
            {
                await _userlanguageRepository.AddUserLanguageAsync(new UserLanguage { UserID = user.UserID, LanguageID = languageID });
            }
            foreach (var response in model.Responses)
            {
                await _userresponseRepository.AddUserResponseAsync(new UserResponse 
                { 
                    UserID = user.UserID,
                    QuestionID = response.QuestionId,
                    ResponseOptionID = response.ResponseId
                });
            }
        }
    }
}