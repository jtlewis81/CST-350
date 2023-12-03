using Microsoft.AspNetCore.Mvc;
using Minesweeper.Models;
using System.Diagnostics;
/*
 * CST-350
 * Home Controller
 * This is the application's landing page
 * 
 */
namespace Minesweeper.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // home/index view
        public IActionResult Index(UserModel user)
        {
            // if a user is logged in they are rerouted to the dashboard
            if (!string.IsNullOrEmpty(user.UserName)) 
            {
                return RedirectToAction("Index", "Dashboard", user);
            }
            else
            {
                return View();
            }
            
        }

        // home/privacy view (privacy policy)
        public IActionResult Privacy()
        {
            return View();
        }

        // home/error view
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
