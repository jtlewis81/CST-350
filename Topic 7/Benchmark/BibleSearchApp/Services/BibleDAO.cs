using BibleSearchApp.Models;
using System.Data.SqlClient;

namespace BibleSearchApp.Services
{
    /// <summary>
    /// 
    ///     Data Access Object for the local test database
    ///     This is referenced by the BibleSearchService class.
    ///     
    ///     Each method:
    ///     - instantiates an empty list of VerseModel objects
    ///     - instantiates the apppropriate sql statement string
    ///     - opens a connection to the database using the class connection string
    ///     - runs the query command using the sql statement
    ///     - reads data and adds to the list as appropriate
    ///     - returns the list of data if no errors occured
    /// 
    /// </summary>
    /// 
    public class BibleDAO
    {
        // connection string for the test database server
        // "KJVBible" referenced in "Initial Catalog" is the name of the database being used
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=KJVBible;";

        // collect records from the whole bible in which the text column contains the search term
        public List<VerseModel> SearchBible(string term)
        {
            List<VerseModel> verses = new List<VerseModel>();

            string sqlStatement = "SELECT * FROM dbo.t_kjv WHERE t LIKE @Text";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.AddWithValue("@Text", '%' + term + '%');

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        verses.Add(new VerseModel((int)reader[0], (int)reader[1], (int)reader[2], (int)reader[3], (string)reader[4]));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return verses;
        }

        // collect records from the new testament books in which the text column contains the search term
        public List<VerseModel> SearchNT(string term)
        {
            List<VerseModel> verses = new List<VerseModel>();

            string sqlStatement = "SELECT * FROM dbo.t_kjv WHERE b >= 40 AND t LIKE @Text";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.AddWithValue("@Text", '%' + term + '%');

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        verses.Add(new VerseModel((int)reader[0], (int)reader[1], (int)reader[2], (int)reader[3], (string)reader[4]));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return verses;
        }

        // collect records from the old testament books in which the text column contains the search term
        public List<VerseModel> SearchOT(string term)
        {
            List<VerseModel> verses = new List<VerseModel>();

            string sqlStatement = "SELECT * FROM dbo.t_kjv WHERE b < 40 AND t LIKE @Text";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.AddWithValue("@Text", '%' + term + '%');

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        verses.Add(new VerseModel((int)reader[0], (int)reader[1], (int)reader[2], (int)reader[3], (string)reader[4]));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return verses;
        }
    }
}