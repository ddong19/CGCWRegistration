using CGCWRegistration.DAL.AgeRangeRepository;
using CGCWRegistration.DAL.LanguageRepository;
using CGCWRegistration.DAL.QuestionRepository;
using CGCWRegistration.DAL.UserRepository;
using CGCWRegistration.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace CGCWRegistration.Controllers
{
    public class TestController : Controller
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IAgeRangeRepository _ageRangeRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IUserRepository _userRepository;

        public TestController(ILanguageRepository languageRepository, IAgeRangeRepository ageRangeRepository, IQuestionRepository questionRepository, IUserRepository userRepository)
        {
            _languageRepository = languageRepository;
            _ageRangeRepository = ageRangeRepository;
            _questionRepository = questionRepository;
            _userRepository = userRepository;
        }

        public async Task<ActionResult> Index()
        {
            var viewModel = new TestViewModel
            {
                Languages = await _languageRepository.GetAllLanguagesAsync(),
                AgeRanges = await _ageRangeRepository.GetAllAgeRangesAsync(),
                Questions = await _questionRepository.GetAllQuestionsAsync(),
                Users = await _userRepository.GetAllAgeUsersAsync()
            };
            return View(viewModel);
        }
    }
}