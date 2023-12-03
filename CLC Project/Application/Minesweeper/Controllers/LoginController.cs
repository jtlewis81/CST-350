using Microsoft.AspNetCore.Mvc;
using Minesweeper.Models;
using Minesweeper.Services;

namespace Minesweeper.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProcessLogin(UserModel user)
        {
            SecurityService securityService = new SecurityService();

            if (securityService.IsValid(user))
            {
                return RedirectToAction("Index", "Dashboard", user);
            }
            else
            {
                ViewBag.Error = "Invalid Credentials!";
                return View("Index");
            }
        }
    }
}
