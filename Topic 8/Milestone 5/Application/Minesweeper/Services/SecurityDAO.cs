using Minesweeper.Models;
using System.Data.SqlClient;

namespace Minesweeper.Services
{
    public class SecurityDAO
    {
        const string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Minesweeper;Integrated Security=True;";

        /// <summary>
        /// Method for checking if a user with some username && password exists (both must match the same user id)
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool UsernameAndPasswordIsValid(UserModel user)
        {
            bool success = false;

            string sqlStatement = "SELECT * FROM dbo.Users WHERE username = @username and password = @password";

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@USERNAME", System.Data.SqlDbType.VarChar, 40).Value = user.UserName;
                command.Parameters.Add("@PASSWORD", System.Data.SqlDbType.VarChar, 40).Value = user.Password;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
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
        
        
        /// <summary>
        /// This method checks to see if t user already is in the database 
        /// </summary>
        /// <param name="user"></param>
        /// <returns>false if not user exist and true if they do</returns>
        public bool FindUserByNameAndEmail(UserModel user)
        {
            // set exists = false 
            bool exists = false;
            // select if user name or email matches
            string sqlStatement = "SELECT * FROM dbo.Users WHERE username = @username or email = @email";

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@USERNAME", System.Data.SqlDbType.VarChar, 40).Value = user.UserName;
                command.Parameters.Add("@EMAIL", System.Data.SqlDbType.VarChar, 40).Value = user.Email;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    // a row grabbed from the query so that means a user with that exits so we set to true
                    if (reader.HasRows)
                    {
                        exists = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            
            return exists;
        }

        // Method to add a new user to the database
        public void AddUser(UserModel user)
        {
            //bool success = false;

            string sqlStatement = "INSERT INTO dbo.Users (firstname, lastname, sex, age, state, email, username, password) values (@firstname, @lastname, @sex, @age, @state, @email, @username, @password)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(sqlStatement, connection);

                    command.Parameters.Add("@FIRSTNAME", System.Data.SqlDbType.VarChar, 20).Value = user.FirstName;
                    command.Parameters.Add("@LASTNAME", System.Data.SqlDbType.VarChar, 20).Value = user.LastName;
                    command.Parameters.Add("@SEX", System.Data.SqlDbType.VarChar, 1).Value = user.Sex;
                    command.Parameters.Add("@AGE", System.Data.SqlDbType.Int).Value = user.Age;
                    command.Parameters.Add("@STATE", System.Data.SqlDbType.VarChar, 2).Value = user.State;
                    command.Parameters.Add("@EMAIL", System.Data.SqlDbType.VarChar, 40).Value = user.Email;
                    command.Parameters.Add("@USERNAME", System.Data.SqlDbType.VarChar, 40).Value = user.UserName;
                    command.Parameters.Add("@PASSWORD", System.Data.SqlDbType.VarChar, 40).Value = user.Password;
                
                    connection.Open();
                    //SqlDataReader reader = command.ExecuteReader();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

           
        }

        // returns a user's Id based on their username and password
        public int GetUserIdUsingUsernameAndPassword(UserModel user)
        {
            int userId = -1;

            string sqlStatement = "SELECT * FROM dbo.Users WHERE username = @username and password = @password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@USERNAME", System.Data.SqlDbType.VarChar, 40).Value = user.UserName;
                command.Parameters.Add("@PASSWORD", System.Data.SqlDbType.VarChar, 40).Value = user.Password;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read(); // Move to the first (and only) row

                        // Assuming UserId is an integer, adjust the column name accordingly
                        userId = reader.GetInt32(reader.GetOrdinal("ID"));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return userId;
        }

        // returns a complete UserModel based on a user's Id
        public UserModel FindUserById(int userId)
        {
            UserModel resultUser = null;

            string sqlStatement = "SELECT * FROM dbo.Users WHERE ID = @userId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@userId", System.Data.SqlDbType.Int).Value = userId;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read(); // Move to the first (and only) row

                        // Assuming UserId is an integer, adjust the column name accordingly
                        int id = reader.GetInt32(reader.GetOrdinal("ID"));
                        // Assuming other properties in UserModel, adjust accordingly
                        string username = reader.GetString(reader.GetOrdinal("USERNAME"));
                        string password = reader.GetString(reader.GetOrdinal("PASSWORD"));
                        string firstName = reader.GetString(reader.GetOrdinal("FIRSTNAME"));
                        string lastName = reader.GetString(reader.GetOrdinal("LASTNAME"));
                        int age = reader.GetInt32(reader.GetOrdinal("AGE"));
                        string sex = reader.GetString(reader.GetOrdinal("SEX"));
                        string state = reader.GetString(reader.GetOrdinal("STATE"));
                        string email = reader.GetString(reader.GetOrdinal("EMAIL"));

                        resultUser = new UserModel
                        {
                            Id = id,
                            FirstName = firstName,
                            LastName = lastName,
                            Sex = sex,
                            Age = age,
                            State = state,
                            Email = email,
                            UserName = username,
                            Password = password
                        };
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return resultUser;
        }

    }
}
