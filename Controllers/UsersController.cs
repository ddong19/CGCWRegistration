using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CGCWRegistration.BLL;
using CGCWRegistration.BLL.UsersService;
using CGCWRegistration.DAL;
using CGCWRegistration.Models;

namespace CGCWRegistration.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }


        [Route("users")]
        public async Task<ActionResult> Users()
        {
            var viewModel = await _usersService.PrepareUsersViewModelAsync();
            return View("Index", viewModel);
        }
    }
}