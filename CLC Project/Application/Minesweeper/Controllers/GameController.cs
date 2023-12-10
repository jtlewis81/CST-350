using Microsoft.AspNetCore.Mvc;
using Minesweeper.Models;
using NuGet.Protocol.Plugins;
using System.Drawing;

namespace Minesweeper.Controllers
{
    public class GameController : Controller
    {
        static GameBoardModel gameBoard;
        int gameBoardSize = 8;
        double bombRatio = 0.10;

        public IActionResult Index()
        {
            gameBoard = new GameBoardModel(gameBoardSize, bombRatio);
            gameBoard.SetupLiveNeighbors();
            gameBoard.CalculateLiveNeighbors();
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
                //gameBoard.grid[row, col].active = false;

                // logic for the flood fill. Only occurs on cells with a 0 neightbor count
                if (gameBoard.grid[row, col].liveNeighbors == 0)
                {
                    gameBoard.grid[row, col].active = false;
                    // run flood fill method
                    gameBoard.FloodFill(row, col);
                    // display the changes in on the screen 
                    /* un needed sinc it going to send updated game board
                    for (int row = 0; row < gameBoard.size; row++)
                    {
                        for (int col = 0; col < gameBoard.size; col++)
                        {
                            if (gameBoard.grid[row, col].visited && !gameBoard.grid[row, col].live)
                            {
                                btnGrid[row, col].BackColor = Color.DarkGray;
                                btnGrid[row, col].Enabled = false;
                                btnGrid[row, col].BackgroundImage = null;
                                // dsiplays neightbor count if no live nieghbors
                                if (gameBoard.grid[row, col].liveNeighbors != 0)
                                {
                                    btnGrid[row, col].Text = gameBoard.grid[row, col].liveNeighbors.ToString();
                                }
                            }
                        }
                    }*/
                    // change color of button
                    //(sender as Button).BackColor = Color.DarkGray;

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
                                //btnGrid[row, col].BackgroundImage = bitBomb;

                            }
                        }
                    }

                }
                // If there is more than 1 neightbor and is not live 
                // shows neightbor count and changes color and disenables it and sets flagged to false
                else
                {
                    //(sender as Button).Text = gameBoard.grid[r, c].liveNeighbors.ToString();
                    //(sender as Button).BackColor = Color.DarkGray;
                    //(sender as Button).Enabled = false;
                    gameBoard.grid[row, col].flagged = false;
                    gameBoard.grid[row, col].active = false;

                }
            }
        


            // do gameboard logic with passed data

            return View("Index", gameBoard);
        }
    }
}
