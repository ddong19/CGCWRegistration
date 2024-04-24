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

        [HttpPost]
        public async Task<ActionResult> Register(UserRegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                if (Request.IsAjaxRequest())
                {
                    return Json(new { success = false, message = "Invalid input data" });
                }
                // Prepare the same ViewModel with validation messages for non-ajax request
                return View(await _registrationService.PrepareRegistrationViewModelAsync());
            }

            try
            {
                await _registrationService.RegisterUserAsync(model);
                if (Request.IsAjaxRequest())
                {
                    return Json(new { success = true, message = "Registration successful!" });
                }

                            // Clear ModelState to remove old input data
            ModelState.Clear();
            // Prepare a fresh ViewModel
            var newViewModel = await _registrationService.PrepareRegistrationViewModelAsync();
            return View("Register", newViewModel);
            }
            catch (Exception ex)
            {
                if (Request.IsAjaxRequest())
                {
                    return Json(new { success = false, message = ex.Message });
                }
                // Handle error scenario for non-ajax request, perhaps display an error view
                return View("Error");
            }
        }
    }
}