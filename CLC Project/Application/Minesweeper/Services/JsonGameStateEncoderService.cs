using Minesweeper.Models;
using Newtonsoft.Json;

namespace Minesweeper.Services
{
    /// <summary>
    /// 
    ///     JsonGameStateEncoderService
    ///     
    ///     Implements the IEncoder interface
    ///     
    ///     Converts the game state string to/from the JSON format
    /// 
    /// </summary>
    public class JsonGameStateEncoderService : IEncoder
    {
        public GameBoardModel? DecodeGameState(string gameState)
        {
            return JsonConvert.DeserializeObject<GameBoardModel>(gameState);
        }

        public string EncodeGameState(GameBoardModel board)
        {
            return JsonConvert.SerializeObject(board);
        }
    }
}
