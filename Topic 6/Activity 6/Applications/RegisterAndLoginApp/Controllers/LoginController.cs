using Microsoft.AspNetCore.Mvc;
using RegisterAndLoginApp.Models;
using RegisterAndLoginApp.Services;
using RegisterAndLoginApp.Utility;

namespace RegisterAndLoginApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [CustomAuthorization]
        public IActionResult PrivatePage()
        {
            return Content("You should only see this page if you are logged in successfully!");
        }

        [LogActionFilter]
        public IActionResult ProcessLogin(UserModel user)
        {
            SecurityService securityService = new SecurityService();

            if (securityService.IsValid(user))
            {
                MyLogger.GetInstance().Info("Login Success");

                HttpContext.Session.SetString("username", user.UserName);

                return View("LoginSuccess", user);
            }
            else
            {
                MyLogger.GetInstance().Info("Login Failure");

                HttpContext.Session.Remove("username");

                return View("LoginFailure", user);
            }
        }
    }
}
