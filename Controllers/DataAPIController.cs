using CGCWRegistration.DAL.AgeRangeRepository;
using CGCWRegistration.DAL.LanguageRepository;
using CGCWRegistration.DAL.QuestionRepository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CGCWRegistration.Controllers
{
    public class DataAPIController : Controller
    {
        private readonly IAgeRangeRepository ageRangeRepository;
        private readonly ILanguageRepository languageRepository;
        private readonly IQuestionRepository questionRepository;

        public DataAPIController(IAgeRangeRepository ageRangeRepository, ILanguageRepository languageRepository, IQuestionRepository questionRepository)
        {
            this.ageRangeRepository = ageRangeRepository;
            this.languageRepository = languageRepository;
            this.questionRepository = questionRepository;
        }

        [HttpGet]
        [Route("ageranges")]
        public async Task<ActionResult> GetAgeRanges()
        {
            var ageRanges = await ageRangeRepository.GetAllAgeRangesAsync();
            return Json(ageRanges, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("languages")]
        public async Task<ActionResult> GetLanguages()
        {
            var languages = await languageRepository.GetAllLanguagesAsync();
            return Json(languages, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("questions")]
        public async Task<ActionResult> GetQuestions()
        {
            var questions = await questionRepository.GetAllQuestionsAsync();
            return Json(questions, JsonRequestBehavior.AllowGet);
        }
    }
}