using Microsoft.AspNetCore.Mvc;
using Minesweeper.Models;

namespace Minesweeper.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index(UserModel user)
        {
            return View(user);
        }
    }
}
