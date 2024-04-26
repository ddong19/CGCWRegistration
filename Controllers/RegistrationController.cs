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
                return Json(new { success = false, message = "Invalid input data" });
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