using Minesweeper.Models;

namespace Minesweeper.Services
{
    public interface IEncoder
    {
        public string EncodeGameState(GameBoardModel board);
        public GameBoardModel? DecodeGameState(string gameState);

    }
}
