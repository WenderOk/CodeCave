using System;
using MySql.Data.MySqlClient;

namespace ADONET_vs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "server=localhost;port=3306;database=geodb;user=s;password=1234567;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string sqlQuery = "SELECT name, surname FROM users";

                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader.GetString("name");
                            string surname = reader.GetString("surname");

                            Console.WriteLine($"Name: {name}, Surname: {surname}");
                        }
                    }
                }
            }
        }
    }
}
