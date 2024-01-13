using Minesweeper.Models;
using System.Data.SqlClient;

namespace Minesweeper.Services
{
    public class SaveGameDAO
    {
        const string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Minesweeper;Integrated Security=True;";

        // add a saved game and return a success/fail result
        public bool AddSavedGame(SaveGameModel savedGame)
        {
            bool success = false;

            string sqlStatement = "INSERT INTO dbo.Saves (Id, userId, date, state) values (@Id, @UserId, @Date, @State)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(sqlStatement, connection);

                    command.Parameters.AddWithValue("@ID", savedGame.Id);
                    command.Parameters.AddWithValue("@USERNAME", savedGame.UserId);
                    command.Parameters.AddWithValue("@DATE", savedGame.Date);
                    command.Parameters.AddWithValue("@STATE", savedGame.State);

                    connection.Open();

                    if (command.ExecuteNonQuery() > 0)
                    {
                        success = true;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return success;
        }

        // delete a saved game and return a success/fail result
        public bool DeleteSavedGame(int saveGameId)
        {
            bool success = false;

            string sqlStatement = "DELETE FROM dbo.Saves WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.AddWithValue("@ID", saveGameId);

                try
                {
                    connection.Open();

                    if (command.ExecuteNonQuery() > 0)
                    {
                        success = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return success;
        }

        // returns the saved game data for a specified record (by id)
        public SaveGameModel GetSavedGameById(int saveGameId)
        {
            SaveGameModel game = new SaveGameModel();

            string sqlStatement = "SELECT * FROM dbo.Saves WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.AddWithValue("@ID", saveGameId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        game = new SaveGameModel((int)reader[0], (int)reader[1], (DateTime)reader[2], (string)reader[3]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return game;
        }

        // returns a list of saved games for a apecific user (by userid)
        public List<SaveGameModel> GetSavedGamesListByUserId(int userId)
        {
            List<SaveGameModel> gameList = new List<SaveGameModel>();

            string sqlStatement = "SELECT * FROM dbo.Saves WHERE UserId = @UserId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.AddWithValue("@USERID", userId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        gameList.Add(new SaveGameModel((int)reader[0], (int)reader[1], (DateTime)reader[2], (string)reader[3]));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return gameList;
        }

        // returns a list of all saved games in the database without user ids
        // this is used by the API only, not the Service class
        public List<SaveGameModel> GetAllSavedGames()
        {
            List<SaveGameModel> gameList = new List<SaveGameModel>();

            string sqlStatement = "SELECT * FROM dbo.Saves";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        gameList.Add(new SaveGameModel((int)reader[0], -1, (DateTime)reader[2], (string)reader[3]));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return gameList;
        }
    }
}
