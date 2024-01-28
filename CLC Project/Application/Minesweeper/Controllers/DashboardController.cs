using Microsoft.AspNetCore.Mvc;
using Minesweeper.Models;
using Minesweeper.Services;
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
            
            SecurityService securityService = new SecurityService();

            if (securityService.IsValid(user))
            {
<<<<<<< Updated upstream
                //user.Id = securityService.GetUserIdUsingUsernameAndPassword(user);
                //HttpContext.Session.SetString("userId", user.Id.ToString());
=======
                //user.Id = securityService.GetUserId(user);
                HttpContext.Session.SetString("userId", user.Id.ToString());
>>>>>>> Stashed changes
                //UserModel foundUser = securityService.GetUser(user.Id);
                return View(user);
            }
            else
            {
                HttpContext.Session.Remove("userId");
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
