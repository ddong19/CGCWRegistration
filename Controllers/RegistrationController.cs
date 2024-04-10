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

        [HttpGet]
        public async Task<ActionResult> Register()
        {
            var viewModel = new UserRegistrationViewModel
            {
                AgeRanges = await _registrationService.GetAllAgeRangesAsync()
            };

            return View(viewModel);

        }
        [HttpPost]
        public async Task<ActionResult> Register(UserRegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // Reload AgeRanges if re-displaying the form
                model.AgeRanges = await _registrationService.GetAllAgeRangesAsync();
                return View(model);
            }

            var user = new User
            {
                // Assign properties from model to user
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

            // call to RegisterUserAsync in RegistrationService
            await _registrationService.RegisterUserAsync(user);
            
            ModelState.Clear();
            var newViewModel = new UserRegistrationViewModel
            {
                AgeRanges = await _registrationService.GetAllAgeRangesAsync()
            };

            return View("Register", newViewModel);
        }
    }
}