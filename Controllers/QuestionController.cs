using CGCWRegistration.DAL.QuestionRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CGCWRegistration.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionController(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<ActionResult> Index()
        {
            var questions = await _questionRepository.GetAllQuestionsAsync();
            return View(questions);
        }
    }

}