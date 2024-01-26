using Minesweeper.Models;

namespace Minesweeper.Services
{
    public class CustomGameStateEncoderService : IEncoder
    {
        public GameBoardModel DecodeGameState(string gameState)
        {
            GameBoardModel gameBoard = new GameBoardModel();

            // get the array of gameBoard details
            // the first 6 elements in the array are gameBoard properties
            // the rest are the individual cells
            string[] gameDetails = gameState.Split("|");

            gameBoard.Size = int.Parse(gameDetails[0]);
            gameBoard.BombRatio = double.Parse(gameDetails[1]);
            gameBoard.TotalCells = int.Parse(gameDetails[2]);
            gameBoard.LiveCells = int.Parse(gameDetails[3]);
            gameBoard.NonLiveCells = int.Parse(gameDetails[4]);
            gameBoard.FirstClick = bool.Parse(gameDetails[5]);
            gameBoard.Grid = new CellModel[gameBoard.Size, gameBoard.Size];
            // used to increment through gameDetails for the cells
            int gameDetailsIndex = 6;

            // parse the gameState string and update the gameBoard.Grid cells with their respective cellState
            for (int r = 0; r < gameBoard.Size; r++)
            {
                for (int c = 0; c < gameBoard.Size; c++)
                {
                    // initialize CellModel before assigning values
                    gameBoard.Grid[r, c] = new CellModel();

                    // get the array of cell details
                    string[] cellDetails = gameDetails[gameDetailsIndex].Split(",");

                    gameBoard.Grid[r, c].Row = int.Parse(cellDetails[0]);
                    gameBoard.Grid[r, c].Column = int.Parse(cellDetails[1]);
                    gameBoard.Grid[r, c].Visited = bool.Parse(cellDetails[2]);
                    gameBoard.Grid[r, c].Live = bool.Parse(cellDetails[3]);
                    gameBoard.Grid[r, c].LiveNeighbors = int.Parse(cellDetails[4]);
                    gameBoard.Grid[r, c].Flagged = bool.Parse(cellDetails[5]);

                    // increment through gameDetails unless this is the last index, which will also be the last cell in gameBoard.Grid
                    if (gameDetailsIndex < gameDetails.Length - 1)
                    {
                        gameDetailsIndex++;
                    }
                }
            }

            return gameBoard;
        }

        public string EncodeGameState(GameBoardModel board)
        {
            string state = "";

            // iterate through the gameboard and add the state of each cell to a parsable string

            state += board.Size.ToString() + "|";
            state += board.BombRatio.ToString() + "|";
            state += board.TotalCells.ToString() + "|";
            state += board.LiveCells.ToString() + "|";
            state += board.NonLiveCells.ToString() + "|";
            state += board.FirstClick.ToString() + "|";

            for (int r = 0; r < board.Size; r++)
            {
                for (int c = 0; c < board.Size; c++)
                {
                    state += board.Grid[r, c].Row.ToString() + ",";
                    state += board.Grid[r, c].Column.ToString() + ",";
                    state += board.Grid[r, c].Visited.ToString() + ",";
                    state += board.Grid[r, c].Live.ToString() + ",";
                    state += board.Grid[r, c].LiveNeighbors.ToString() + ",";
                    state += board.Grid[r, c].Flagged.ToString() + ",";

                    // do not add separator after last cell
                    if (!(r == board.Size - 1 && c == board.Size - 1))
                    {
                        state += "|";
                    }
                }
            }

            return state;
        }
    }
}
