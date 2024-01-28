using Minesweeper.Models;

namespace Minesweeper.Services
{
    public class SaveGameService
    {
        SaveGameDAO saveGameDAO;
        IEncoder encoder;

        // constructor
        public SaveGameService(IEncoder encoderService)
        {
            encoder = encoderService;
            saveGameDAO = new SaveGameDAO();
        }

        // save a game
        public bool SaveGame(int userId, GameBoardModel gameBoard)
        {
            return saveGameDAO.AddSavedGame(new SaveGameModel(userId, DateTime.Now, encoder.EncodeGameState(gameBoard)));
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
            return gamestate != null ? encoder.DecodeGameState(gamestate) : null;
        }

        // delete a game by its Id

        public bool DeleteGame(int saveGameId)
        {
            return saveGameDAO.DeleteSavedGame(saveGameId);
        }
    }
}
