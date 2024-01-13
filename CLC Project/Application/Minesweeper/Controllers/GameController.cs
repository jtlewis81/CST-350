using Microsoft.AspNetCore.Mvc;
using Minesweeper.Models;
using Minesweeper.Services;

namespace Minesweeper.Controllers
{
    /// <summary>
    ///
    ///     This updates the partial view for the game within the logged in user's Dashboard page
    /// 
    /// </summary>
    
    public class GameController : Controller
    {

        static GameBoardModel gameBoard;
        GameLogicService gameLogic = new GameLogicService();

        // hard coded for now but will be determined by the difficulty chosen
        int gameBoardSize = 8;
        // the GameboardModel class has an array of doubles called Difficulty,
        // so we only need to pass an int once we implement the game settings feature
        double bombRatio = 0.10;

        // GET /Game/
        public IActionResult Index()
        {
            gameBoard = new GameBoardModel(gameBoardSize, bombRatio);
            gameBoard = gameLogic.Setup(gameBoard);
            // add method to the GameLogicService to start the timer (it might need to run in a separate partial view?)
            return PartialView("_Minesweeper", gameBoard);
        }

        /// <summary>
        /// 
        /// HandleLeftClick and HandleRightClick actions passes current gameBoard data to the GameLogicService
        /// passes the updated gameBoard, returned from the GameLogicService, to the partial View
        /// game over conditions are checked and ViewBag.Message is updated appropriately.
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>

        public IActionResult HandleLeftClick(int row, int col)
        {
            gameBoard = gameLogic.LeftClick(gameBoard, row, col);

            if (gameLogic.GameOverWin(gameBoard))
            {
                ViewBag.Message = "GAME OVER! You WIN! All non-live cells visited.\nQUIT to close the game or PLAY start a new game.";
            }
            else if (gameLogic.GameOverLose(gameBoard))
            {
                ViewBag.Message = "GAME OVER! You LOSE! You visited a live cell.\nQUIT to close the game or PLAY start a new game.";
            }

            return PartialView("_GameBoard", gameBoard);
        }

        public IActionResult HandleRightClick(int row, int col)
        {
            gameBoard = gameLogic.RightClick(gameBoard, row, col);

            if (gameLogic.GameOverWin(gameBoard))
            {
                ViewBag.Message = "GAME OVER! You WIN! All non-live cells visited.\nQUIT to close the game or PLAY start a new game.";
            }
            else if (gameLogic.GameOverLose(gameBoard))
            {
                ViewBag.Message = "GAME OVER! You LOSE! You visited a live cell.\nQUIT to close the game or PLAY start a new game.";
            }

            return PartialView("_GameBoard", gameBoard);
        }
    }
}
