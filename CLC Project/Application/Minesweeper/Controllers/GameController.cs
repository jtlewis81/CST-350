using Microsoft.AspNetCore.Mvc;
using Minesweeper.Models;

namespace Minesweeper.Controllers
{
    public class GameController : Controller
    {
        static GameBoardModel gameBoard;
        // hard coded for now but will be dtiremented by the difficulty chosen
        int gameBoardSize = 8;
        double bombRatio = 0.10;

        public IActionResult Index()
        {
            gameBoard = new GameBoardModel(gameBoardSize, bombRatio);
            gameBoard.SetupLiveNeighbors();
            gameBoard.CalculateLiveNeighbors();
            return View("Index", gameBoard);
        }

        // do gameboard logic with passed data
        public IActionResult HandleClick(int row, int col)
        {
            // Only can click a cell that is not flagged so no accidents
            if (!gameBoard.grid[row, col].flagged)
            {

                // first click so it moves if bomb also starts timer
                if (gameBoard.firstClick)
                {
                    //FirstClick(r,c);
                    //watch.Start();
                    //gameBoard.firstClick = false;
                }
                // sets visited to true
                gameBoard.grid[row, col].visited = true;

                // logic for the flood fill. Only occurs on cells with a 0 neightbor count
                if (gameBoard.grid[row, col].liveNeighbors == 0)
                {
                    gameBoard.grid[row, col].active = false;
                    // run flood fill method
                    gameBoard.FloodFill(row, col);
                    

                }
                else if (gameBoard.grid[row, col].live == true)
                {
                    // if the cell chose is i live show the bomb
                    ///btnGrid[r, c].BackgroundImage = bitBomb;
                    // we also want all the cells that are bombs to be shown to the user so thats what this nest for loop is for
                    for (int r = 0; r < gameBoard.size; r++)
                    {
                        for (int c = 0; c < gameBoard.size; c++)
                        {
                            if (gameBoard.grid[r, c].live)
                            {
                                gameBoard.grid[r, c].visited = true;

                            }
                        }
                    }

                }
                // If there is more than 1 neightbor and is not live 
                // shows neightbor count and changes color and disenables it and sets flagged to false
                else
                {
                    gameBoard.grid[row, col].flagged = false;
                    gameBoard.grid[row, col].active = false;

                }
            }

            return View("Index", gameBoard);
        }


        public IActionResult HandleLeftClick(int row, int col)
        {
            // Only can click a cell that is not flagged so no accidents
            if (!gameBoard.grid[row, col].flagged)
            {

                // first click so it moves if bomb also starts timer
                if (gameBoard.firstClick)
                {
                    //FirstClick(r,c);
                    //watch.Start();
                    //gameBoard.firstClick = false;
                }
                // sets visited to true
                gameBoard.grid[row, col].visited = true;

                // logic for the flood fill. Only occurs on cells with a 0 neightbor count
                if (gameBoard.grid[row, col].liveNeighbors == 0)
                {
                    gameBoard.grid[row, col].active = false;
                    // run flood fill method
                    gameBoard.FloodFill(row, col);


                }
                else if (gameBoard.grid[row, col].live == true)
                {
                    // if the cell chose is i live show the bomb
                    ///btnGrid[r, c].BackgroundImage = bitBomb;
                    // we also want all the cells that are bombs to be shown to the user so thats what this nest for loop is for
                    for (int r = 0; r < gameBoard.size; r++)
                    {
                        for (int c = 0; c < gameBoard.size; c++)
                        {
                            if (gameBoard.grid[r, c].live)
                            {
                                gameBoard.grid[r, c].visited = true;

                            }
                        }
                    }

                }
                // If there is more than 1 neightbor and is not live 
                // shows neightbor count and changes color and disenables it and sets flagged to false
                else
                {
                    gameBoard.grid[row, col].flagged = false;
                    gameBoard.grid[row, col].active = false;

                }
            }

            return PartialView("_BoardUpdate", gameBoard);
        }



        public IActionResult HandleRightClick(int row, int col)
        {
            // if the image is not currently flagged then flag it
            // if it is flagged  then remove the flag
            if (!gameBoard.grid[row, col].flagged)
            {
               //btnGrid[r, c].BackgroundImage = bitFlag;
                gameBoard.grid[row, col].flagged = true;
                //gameBoard.grid[row, col].active = false;
            }
            else
            {
                //btnGrid[r, c].BackgroundImage = null;
                gameBoard.grid[row, col].flagged = false;
                //gameBoard.grid[row, col].active = true;
            }

            return PartialView("_BoardUpdate", gameBoard);
        }



    }
}
