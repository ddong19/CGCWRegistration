using CGCWRegistration.BLL;
using CGCWRegistration.Models;
using CGCWRegistration.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace CGCWRegistration.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        // GET
        [HttpGet]
        public async Task<ActionResult> Register()
        {
            var viewModel = await _registrationService.PrepareRegistrationViewModelAsync();
            return View(viewModel);
        }

        // POST
        [HttpPost]
        public async Task<ActionResult> Register(UserRegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(await _registrationService.PrepareRegistrationViewModelAsync());
            }
            // Register user to database
            await _registrationService.RegisterUserAsync(model);
            // Clear ModelState to remove old input data
            ModelState.Clear();
            // Prepare a fresh ViewModel
            var newViewModel = await _registrationService.PrepareRegistrationViewModelAsync();
            return View("Register", newViewModel);
        }
    }
}