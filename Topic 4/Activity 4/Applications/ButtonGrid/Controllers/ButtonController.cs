using ButtonGrid.Models;
using Microsoft.AspNetCore.Mvc;

namespace ButtonGrid.Controllers
{
    public class ButtonController : Controller
    {
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
            return View("Index", buttons);
        }

        public IActionResult ShowOneButton(int buttonNumber)
        {
            buttons.ElementAt(buttonNumber).ButtonState = (buttons.ElementAt(buttonNumber).ButtonState + 1) % 4;

            return PartialView(buttons.ElementAt(buttonNumber));
        }
    }
}
