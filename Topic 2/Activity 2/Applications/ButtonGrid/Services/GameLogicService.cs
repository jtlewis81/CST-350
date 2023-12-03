using ButtonGrid.Models;

namespace ButtonGrid.Services
{
    public class GameLogicService
    {
        public GameLogicService() { }

        public bool AllButtonsMatch(List<ButtonModel> buttons)
        {
            int btnState = buttons.ElementAt(0).ButtonState;

            foreach (var btn in buttons)
            {
                if (btn.ButtonState != btnState)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
