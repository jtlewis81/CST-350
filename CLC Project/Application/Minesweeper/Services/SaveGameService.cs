using Minesweeper.Models;

namespace Minesweeper.Services
{
    public class SaveGameService
    {
        SaveGameDAO saveGameDAO = new SaveGameDAO();

        // save a game
        public bool SaveGame(int userId, GameBoardModel gameBoard)
        {
            return saveGameDAO.AddSavedGame(new SaveGameModel(userId, DateTime.Now, EncodeGameStateToString(gameBoard)));
        }

        // get a list of saved games for a specific user
        public List<SaveGameModel> GetSavesByUserId(int userId)
        {
            return saveGameDAO.GetSavedGamesListByUserId(userId);
        }

        // return the GameBoardModel for a specified saved game
        public GameBoardModel? LoadGame(int saveGameId)
        {
            string? gamestate = saveGameDAO.GetSavedGameById(saveGameId).State;
            return gamestate != null ? ParseGameState(gamestate) : null;
        }

        // Helper Methods

        public bool DeleteGame(int saveGameId)
        {
            return saveGameDAO.DeleteSavedGame(saveGameId);
        }

        private string EncodeGameStateToString(GameBoardModel gameBoard)
        {
            string state = "";

            // iterate through the gameboard and add the state of each cell to a parsable string

            state += gameBoard.Size.ToString() + "|";
            state += gameBoard.BombRatio.ToString() + "|";
            state += gameBoard.TotalCells.ToString() + "|";
            state += gameBoard.LiveCells.ToString() + "|";
            state += gameBoard.NonLiveCells.ToString() + "|";
            state += gameBoard.FirstClick.ToString() + "|";

            for (int r = 0; r < gameBoard.Size; r++)
            {
                for (int c = 0; c < gameBoard.Size; c++)
                {
                    state += gameBoard.Grid[r, c].Row.ToString() + ",";
                    state += gameBoard.Grid[r, c].Column.ToString() + ",";
                    state += gameBoard.Grid[r, c].Visited.ToString() + ",";
                    state += gameBoard.Grid[r, c].Live.ToString() + ",";
                    state += gameBoard.Grid[r, c].LiveNeighbors.ToString() + ",";
                    state += gameBoard.Grid[r, c].Flagged.ToString() + ",";

                    // do not add separator after last cell
                    if (!(r == gameBoard.Size - 1 && c == gameBoard.Size - 1))
                    {
                        state += "|";
                    }
                }
            }

            return state;
        }

        private GameBoardModel ParseGameState(string gameState)
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

            // used to increment through gameDetails for the cells
            int gameDetailsIndex = 6;

            // parse the gameState string and update the gameBoard.Grid cells with their respective cellState
            for (int r = 0; r < gameBoard.Size; r++)
            {
                for (int c = 0; c < gameBoard.Size; c++)
                {
                    // get the array of cell details
                    string[] cellDetails = gameDetails[gameDetailsIndex].Split(",");

                    gameBoard.Grid[r, c].Row = int.Parse(cellDetails[0]);
                    gameBoard.Grid[r, c].Column = int.Parse(cellDetails[0]);
                    gameBoard.Grid[r, c].Visited = bool.Parse(cellDetails[0]);
                    gameBoard.Grid[r, c].Live = bool.Parse(cellDetails[0]);
                    gameBoard.Grid[r, c].LiveNeighbors = int.Parse(cellDetails[0]);
                    gameBoard.Grid[r, c].Flagged = bool.Parse(cellDetails[0]);

                    // increment through gameDetails unless this is the last index, which will also be the last cell in gameBoard.Grid
                    if (gameDetailsIndex < gameDetails.Length - 1)
                    {
                        gameDetailsIndex++;
                    }
                }
            }

            return gameBoard;
        }

    }
}
