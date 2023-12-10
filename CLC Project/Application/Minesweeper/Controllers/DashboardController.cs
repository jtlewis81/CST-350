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
        int boardSize = 8;

        // dashboard/index view
        public IActionResult Index(UserModel user)
        {
            return View(user);
        }

        public IActionResult NewGame()
        {
            return RedirectToAction("Index", "Game");
        }

        public IActionResult HandleClick(int row, int col)
        {
            // do gameboard logic with passed data

            return View("Game");
        }

    }
}
