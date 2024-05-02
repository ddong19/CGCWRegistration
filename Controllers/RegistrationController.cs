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
        [Route("register")]
        public async Task<ActionResult> Register()
        {
            var viewModel = await _registrationService.PrepareRegistrationViewModelAsync();
            return View(viewModel);
        }

        // POST
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register(UserRegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                foreach (var key in ModelState.Keys)
                {
                    foreach (var error in ModelState[key].Errors)
                    {
                        System.Diagnostics.Debug.WriteLine($"Key: {key}, Error: {error.ErrorMessage}");
                    }
                }
                var errors = ModelState
                    .Where(kvp => kvp.Value.Errors.Count > 0)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());

                return Json(new { success = false, error = errors });
            }
            try
            {
                await _registrationService.RegisterUserAsync(model);
                return Json(new { success = true, message = "Registration successful!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}