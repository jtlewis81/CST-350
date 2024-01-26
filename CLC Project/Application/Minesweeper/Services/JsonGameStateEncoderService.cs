using Minesweeper.Models;
using Newtonsoft.Json;

namespace Minesweeper.Services
{
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
