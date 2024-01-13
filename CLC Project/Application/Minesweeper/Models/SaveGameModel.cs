namespace Minesweeper.Models
{
    public class SaveGameModel
    {
        // unique id of the save game
        public int Id { get; set; }

        // user id associated with the saved game
        public int UserId { get; set; }

        // the time the game was saved
        public DateTime Date { get; set; }

        // a string representation of the game state data
        public string? State { get; set; }

        // default constructor 
        public SaveGameModel() { }

        // normal constructor
        public SaveGameModel(int userId, DateTime date, string? state)
        {
            UserId = userId;
            Date = date;
            State = state;
        }

        // full constructor
        public SaveGameModel(int id, int userId, DateTime date, string? state)
        {
            Id = id;
            UserId = userId;
            Date = date;
            State = state;
        }
    }
}
