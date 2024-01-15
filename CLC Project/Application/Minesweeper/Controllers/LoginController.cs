using Microsoft.AspNetCore.Mvc;
using Minesweeper.Models;
using Minesweeper.Services;
/*
 * CST-350
 * Login Controller
 * This handles the user login
 * 
 */
namespace Minesweeper.Controllers
{
    public class LoginController : Controller
    {
        // login/index view
        public IActionResult Index()
        {
            return View();
        }

        // login/processLogin view
        // handles where to send the user if login is succeessful or fails
        [HttpPost]
        public IActionResult ProcessLogin(UserModel user)
        {
            SecurityService securityService = new SecurityService();

            // successful login takes user to dashboard
            if (securityService.IsValid(user))
            {
                user.Id = securityService.GetUserId(user);
                HttpContext.Session.SetString("userId", user.Id.ToString());
                UserModel foundUser = securityService.GetUser(user.Id);
                return RedirectToAction("Index", "Dashboard", user);
            }
            // login failure reloads login/index with error message displayed
            else
            {
                ViewBag.Error = "Invalid Credentials!";
                return View("Index");
            }
        }
    }
}
