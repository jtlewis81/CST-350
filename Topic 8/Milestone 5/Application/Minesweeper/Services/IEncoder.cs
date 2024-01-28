using Minesweeper.Models;

namespace Minesweeper.Services
{
    /// <summary>
    /// 
    ///     IEncoder interface
    ///     
    ///     Used by the SaveGameService to convert data before interacting with the DAO
    /// 
    /// </summary>
    public interface IEncoder
    {
        // Take a GameBoardModel object and convert it to a string
        // representing the game state that can be saved in the database
        public string EncodeGameState(GameBoardModel board);
        
        // Parse the gamestate string saved in the database back to a GameBoardModel object
        public GameBoardModel? DecodeGameState(string gameState);

    }
}
