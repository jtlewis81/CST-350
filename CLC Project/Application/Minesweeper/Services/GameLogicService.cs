using Minesweeper.Models;

namespace Minesweeper.Services
{
    public class GameLogicService
    {
        public GameLogicService()
        {

        }

        // public property for lose condition (is set to true if a live cell is left clicked)
        public bool GameOverLose(GameBoardModel gameBoard)
        {
            foreach (CellModel cell in gameBoard.Grid)
            {
                if (cell.Live && cell.Visited)
                {
                    return true;
                }
            }
            // only returns false if no live cells have been visited
            return false;
        }

        // method for checking if the player has cleared all non-live cells on the board
        public bool GameOverWin(GameBoardModel gameBoard)
        {
            return gameBoard.NonLiveCells == getNumberOfVistedCells(gameBoard);
        }

        // helper method for counting visited cells
        private int getNumberOfVistedCells(GameBoardModel gameBoard)
        {
            int visitedCells = 0;
            foreach (CellModel cell in gameBoard.Grid)
            {
                if (cell.Visited) visitedCells++;
            }
            return visitedCells;
        }

        public GameBoardModel Setup(GameBoardModel gameBoard)
        {
            gameBoard = SetupLiveNeighbors(gameBoard);
            gameBoard = CalculateLiveNeighbors(gameBoard);
            return gameBoard;
        }

        // Randomly initailize the grid with Live bombs based on diffculty
        private GameBoardModel SetupLiveNeighbors(GameBoardModel gameBoard)
        {
            // calculate Live cells
            gameBoard.LiveCells = (int)(gameBoard.BombRatio * gameBoard.TotalCells);
            // calculate non Live cells
            gameBoard.NonLiveCells = gameBoard.TotalCells - gameBoard.LiveCells;
            // Random fill the cells
            Random random = new Random();
            for (int i = 0; i < gameBoard.LiveCells; i++)
            {
                int randomRow = random.Next(gameBoard.Size);
                int randomColumn = random.Next(gameBoard.Size);

                // Check if the cell is already Live, and if not, set it as Live
                if (!gameBoard.Grid[randomRow, randomColumn].Live)
                {
                    gameBoard.Grid[randomRow, randomColumn].Live = true;
                }
                else
                {
                    // If the cell is already Live, try again with a different cell
                    i--;
                }
            }

            return gameBoard;
        }

        /* This calculates the number of Live neightbors 
         * We create two arrays to get the neighbors of the cell and ask of they are Live
         * If that neightbot is Live it adds to the Live nieghbors count
         * There are 8 neighbors to each cell becuase we count the corners and the sides
         * We also skip checking the neighbor if the neighbor is not part of the board. 
         */

        private GameBoardModel CalculateLiveNeighbors(GameBoardModel gameBoard)
        {
            // These are the arrays that keep track of the neighbors. For example the -1,-1 would be the top left corner of the current cell we are checking.
            int[] dr = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] dc = { -1, 0, 1, -1, 1, -1, 0, 1 };

            for (int row = 0; row < gameBoard.Size; row++)
            {
                for (int col = 0; col < gameBoard.Size; col++)
                {
                    // Variable to keep track of neighbor Live count
                    int liveNeighborCount = 0;

                    for (int i = 0; i < gameBoard.Size; i++)
                    {
                        // Using the arrays to save the temp of the neighbor we are checking
                        int newRow = row + dr[i];
                        int newCol = col + dc[i];

                        if (newRow >= 0 && newRow < gameBoard.Size && newCol >= 0 && newCol < gameBoard.Size && gameBoard.Grid[newRow, newCol].Live)
                        {
                            // adds one to the neighbor count if the neighbor is set to Live
                            liveNeighborCount++;
                        }
                    }
                    // Setting neightbor count to 9 if the cell is Live
                    if (gameBoard.Grid[row, col].Live)
                    {
                        gameBoard.Grid[row, col].LiveNeighbors = 9;
                    }
                    else
                    {
                        // set the temporary count to the cells object Live neighbor count
                        gameBoard.Grid[row, col].LiveNeighbors = liveNeighborCount;
                    }
                }
            }

            return gameBoard;
        }

        // This is for the flood fill 
        // This will flood to any neightbor that has no bombs touching it and if it does have a bomb as a niehtbor it will
        // not go past that but will show as Visited.
        private GameBoardModel FloodFill(GameBoardModel gameBoard, int row, int col)
        {
            // Define the eight possible moves (neighbors)
            int[] dx = { 1, -1, 0, 0, 1, 1, -1, -1 };
            int[] dy = { 0, 0, 1, -1, 1, -1, 1, -1 };

            // Mark the current cell as Visited
            gameBoard.Grid[row, col].Visited = true;
            gameBoard.Grid[row, col].Flagged = false;
            // Iterate through all eight possible neighbors
            for (int i = 0; i < 8; i++)
            {
                int newRow = row + dx[i];
                int newCol = col + dy[i];

                // Check if the neighbor is within the bounds of the grid
                if (newRow >= 0 && newRow < gameBoard.Size && newCol >= 0 && newCol < gameBoard.Size)
                {
                    // Check the condition and recursively fill if met
                    if (!gameBoard.Grid[newRow, newCol].Visited)
                    {
                        if (gameBoard.Grid[newRow, newCol].LiveNeighbors == 0)
                        {
                            gameBoard = FloodFill(gameBoard, newRow, newCol);
                        }
                        // We want the neighbors that have bombs as neightbors to show but we do not want to recursively call after that.
                        else if (gameBoard.Grid[newRow, newCol].Live == false)
                        {
                            gameBoard.Grid[newRow, newCol].Visited = true;
                        }
                    }
                }
            }
            return gameBoard;
        }

        // clears a cell, reveals number of neighbors or if it has a bomb
        public GameBoardModel LeftClick(GameBoardModel gameBoard, int row, int col)
        {
            // Only can click a cell that is not Flagged so no accidents
            if (!gameBoard.Grid[row, col].Flagged && !GameOverLose(gameBoard) && !GameOverWin(gameBoard))
            {
                // first click so it moves if bomb also starts timer
                if (gameBoard.FirstClick)
                {
                    //FirstClick(r,c);
                    //watch.Start();
                    //gameBoard.FirstClick = false;
                }
                // sets Visited to true
                gameBoard.Grid[row, col].Visited = true;

                // logic for the flood fill. Only occurs on cells with a 0 neightbor count
                if (gameBoard.Grid[row, col].LiveNeighbors == 0)
                {
                    // run flood fill method (recursive)
                    FloodFill(gameBoard, row, col);
                }
                else if (gameBoard.Grid[row, col].Live == true)
                {
                    // if the cell is Live show the bomb
                    // we also want all the cells that are bombs to be shown to the user
                    // so thats what this nested for loop is for
                    for (int r = 0; r < gameBoard.Size; r++)
                    {
                        for (int c = 0; c < gameBoard.Size; c++)
                        {
                            if (gameBoard.Grid[r, c].Live)
                            {
                                gameBoard.Grid[r, c].Visited = true;
                            }
                        }
                    }

                }
                // If there is more than 1 neighbor and is not Live 
                // shows neighbor count, changes color, and disables cell
                else
                {
                    gameBoard.Grid[row, col].Visited = true;
                }
            }

            return gameBoard;
        }

        public GameBoardModel RightClick(GameBoardModel gameBoard, int row, int col)
        {
            if (!GameOverLose(gameBoard))
            {
                if (gameBoard.Grid[row, col].Flagged && !GameOverWin(gameBoard))
                {
                    gameBoard.Grid[row, col].Flagged = false;
                }
                else // not flagged
                {
                    if (!gameBoard.Grid[row, col].Visited)
                        gameBoard.Grid[row, col].Flagged = true;
                }
            }

            return gameBoard;
        }
    }
}
