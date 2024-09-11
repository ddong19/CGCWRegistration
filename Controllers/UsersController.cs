using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CGCWRegistration.BLL;
using CGCWRegistration.BLL.UsersService;
using CGCWRegistration.DAL;
using CGCWRegistration.Models;
using CGCWRegistration.Models.ViewModels;

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
        public ActionResult Users()
        {
            return View("Index");
        }

        [Route("users/list")]
        public async Task<ActionResult> ListUsers()
        {
            List<UsersViewModel> users = await _usersService.ListUsersAsync();
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        // GET: User/Delete/5
        [Route("users/delete")]
        public async Task<ActionResult> Delete(int id)
        {
            User user = await _usersService.GetUserByIdAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [Route("users/delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _usersService.DeleteUserByIdAsync(id);
            return RedirectToAction("Index");
        }
    }
}