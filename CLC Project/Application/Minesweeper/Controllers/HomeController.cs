using Microsoft.AspNetCore.Mvc;
using Minesweeper.Models;
using System.Diagnostics;

namespace Minesweeper.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(UserModel user)
        {
            Console.WriteLine("Calling Home/Index with username: " + user.UserName);
            if (!string.IsNullOrEmpty(user.UserName)) 
            {
                return RedirectToAction("Index", "Dashboard", user);
            }
            else
            {
                return View();
            }
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
