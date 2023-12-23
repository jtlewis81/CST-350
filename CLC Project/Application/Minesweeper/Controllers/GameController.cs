﻿using Microsoft.AspNetCore.Mvc;
using Minesweeper.Models;
using Minesweeper.Services;

namespace Minesweeper.Controllers
{
    public class GameController : Controller
    {
        static GameBoardModel gameBoard;
        GameLogicService gameLogic = new GameLogicService();

        // hard coded for now but will be determined by the difficulty chosen
        int gameBoardSize = 8;
        // the GameboardModel class has an array of doubles called Difficulty,
        // so wwe only need to pass an int once we implement the game settings feature
        double bombRatio = 0.10;

        public IActionResult Index()
        {
            gameBoard = new GameBoardModel(gameBoardSize, bombRatio);
            gameBoard = gameLogic.Setup(gameBoard);
            // add method to the GameLogicService to start the timer (it might need to run in a separate partial view?)
            return PartialView("_Minesweeper", gameBoard);
        }

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
