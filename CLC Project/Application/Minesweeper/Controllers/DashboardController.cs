using Microsoft.AspNetCore.Mvc;
using Minesweeper.Models;
/*
 * CST-350
 * Dashboard Controller
 * This is where the user is taken to after logging in
 * 
 */
namespace Minesweeper.Controllers
{
    public class DashboardController : Controller
    {
        // dashboard/index view
        //[HttpPost]
        public IActionResult Index(UserModel user)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("userId")))
            {
                return View(user);
            }
            else
            {
                HttpContext.Session.Remove("userId");
                return RedirectToAction("Index", "Home");
            }
        }

        // handle logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }

    }
}
