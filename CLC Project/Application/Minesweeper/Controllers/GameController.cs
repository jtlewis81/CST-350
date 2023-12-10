using Microsoft.AspNetCore.Mvc;
using Minesweeper.Models;

namespace Minesweeper.Controllers
{
    public class GameController : Controller
    {
        static GameBoardModel gameboardModel;

        public IActionResult Index()
        {
            gameboardModel = new GameBoardModel(8);

            return View(gameboardModel);
        }
    }
}
