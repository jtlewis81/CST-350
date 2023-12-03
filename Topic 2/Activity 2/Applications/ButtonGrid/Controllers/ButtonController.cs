using ButtonGrid.Models;
using ButtonGrid.Services;
using Microsoft.AspNetCore.Mvc;

namespace ButtonGrid.Controllers
{
    public class ButtonController : Controller
    {
        GameLogicService gameLogicService = new GameLogicService();

        static List<ButtonModel> buttons = new List<ButtonModel>();
        Random random = new Random();
        const int GRID_SIZE = 25;

        public IActionResult Index()
        {
            buttons = new List<ButtonModel>();

            for (int i = 0; i < GRID_SIZE; i++)
            {
                buttons.Add(new ButtonModel(i, random.Next(4)));
            }
            ViewBag.Message = "Try to match all the buttons!";
            return View("Index", buttons);
        }

        public IActionResult HandleButtonClick(string buttonNumber)
        {
            int btnNum = int.Parse(buttonNumber);

            buttons.ElementAt(btnNum).ButtonState = (buttons.ElementAt(btnNum).ButtonState + 1) % 4;

            if (gameLogicService.AllButtonsMatch(buttons))
            {
                ViewBag.Message = "Yay! All the button match!";
            }
            else
            {
                ViewBag.Message = "Try to match all the buttons!";
            }

            return View("Index", buttons);
        }
    }
}
