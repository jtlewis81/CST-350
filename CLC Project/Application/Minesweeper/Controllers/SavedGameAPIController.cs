using Minesweeper.Models;
using Minesweeper.Services;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Description;

namespace Minesweeper.Controllers
{
    [ApiController]
    [Route("/api/[Controller]")]
    public class SavedGameAPIController
    {
        SaveGameDAO repository = new SaveGameDAO();

        public SavedGameAPIController()
        {
            repository = new SaveGameDAO();
        }

        // returns a list of all games by default
        [HttpGet]
        [ResponseType(typeof(List<SaveGameModel>))]
        public IEnumerable<SaveGameModel> Index()
        {
            // this method called is specifically for this API controller, and the data does not include user ids
            return repository.GetAllSavedGames();
        }

        // returns saved game data for one specified game
        [HttpGet("showSavedGame/{id}")]
        [ResponseType(typeof(List<SaveGameModel>))]
        public SaveGameModel ShowOneGameById(int id)
        {
            return repository.GetSavedGameById(id);
        }

        // deletes the specified game and returns the updated list of all saved games
        [HttpDelete("deleteOneGame/{id}")]
        [ResponseType(typeof(List<SaveGameModel>))]
        public IEnumerable<SaveGameModel> DeleteOneGameById(int id)
        {
            repository.DeleteSavedGame(id);
            return repository.GetAllSavedGames();
        }
    }
}
