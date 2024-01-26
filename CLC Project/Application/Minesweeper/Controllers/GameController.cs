using Microsoft.AspNetCore.Mvc;
using Minesweeper.Models;
using Minesweeper.Services;
using Newtonsoft.Json;
using System;

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

        GameLogicService gameLogicService;
        SecurityService securityService;
        SaveGameService saveGameService;
        IEncoder encoder;

        public GameController(IEncoder encoderService)
        {
            encoder = encoderService;
            gameLogicService = new GameLogicService();
            securityService = new SecurityService();
            saveGameService = new SaveGameService(encoder);
        }
        
        // default game settings
        int gameBoardSize = 8;
        double bombRatio = 0.10;

        // GET /Game/
        public IActionResult Index()
        {
            gameBoard = new GameBoardModel(gameBoardSize, bombRatio);
            gameBoard = gameLogicService.Setup(gameBoard);
            
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
            // checks for a "fake click" for refreshing board when loading a game
            // there is a method in site.js that calls this controller action,
            //   passing -1 for row and col
            if(row >= 0 && col >= 0)
            {
                gameBoard = gameLogicService.LeftClick(gameBoard, row, col);
            }

            if (gameLogicService.GameOverWin(gameBoard))
            {
                ViewBag.Message = "GAME OVER! You WIN! All non-live cells visited.\nQUIT to close the game or PLAY start a new game.";
            }
            else if (gameLogicService.GameOverLose(gameBoard))
            {
                ViewBag.Message = "GAME OVER! You LOSE! You visited a live cell.\nQUIT to close the game or PLAY start a new game.";
            }

            return PartialView("_GameBoard", gameBoard);
        }

        public IActionResult HandleRightClick(int row, int col)
        {
            gameBoard = gameLogicService.RightClick(gameBoard, row, col);

            if (gameLogicService.GameOverWin(gameBoard))
            {
                ViewBag.Message = "GAME OVER! You WIN! All non-live cells visited.\nQUIT to close the game or PLAY start a new game.";
            }
            else if (gameLogicService.GameOverLose(gameBoard))
            {
                ViewBag.Message = "GAME OVER! You LOSE! You visited a live cell.\nQUIT to close the game or PLAY start a new game.";
            }

            return PartialView("_GameBoard", gameBoard);
        }

        // saved games button
        public IActionResult SavedGames()
        {
            int userId = Int32.Parse(HttpContext.Session.GetString("userId"));
            List<SaveGameModel> savedGames = saveGameService.GetSavesByUserId(userId);

            return PartialView("_SavedGames", savedGames);
        }

        [HttpPost]
        public IActionResult SaveGame()
        {
            int userId = Int32.Parse(HttpContext.Session.GetString("userId"));
            UserModel user = securityService.GetUser(userId);
            saveGameService.SaveGame(userId, gameBoard);
            
            //return PartialView("_Minesweeper", gameBoard);
            return RedirectToAction("Index", "Dashboard", user);
        }

        [HttpGet]
        public IActionResult LoadGame(int gameId)
        {
            Console.Out.WriteLine(gameId);
            gameBoard = saveGameService.LoadGame(gameId);


            return PartialView("_Minesweeper", gameBoard);
        }

        [HttpDelete]
        public IActionResult DeleteGame(int gameId)
        {
            saveGameService.DeleteGame(gameId);
            int userId = Int32.Parse(HttpContext.Session.GetString("userId"));
            List<SaveGameModel> savedGames = saveGameService.GetSavesByUserId(userId);

            return PartialView("_SavedGames", savedGames);
        }
    }
}
