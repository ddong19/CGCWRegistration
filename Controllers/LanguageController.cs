using CGCWRegistration.DAL.LanguageRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CGCWRegistration.Controllers
{
    public class LanguageController : Controller
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageController(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task<ActionResult> Index()
        {
            var languages = await _languageRepository.GetAllLanguagesAsync();
            return View(languages);
        }
    }

}