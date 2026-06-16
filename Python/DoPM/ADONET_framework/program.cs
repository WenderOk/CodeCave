using System;
using MySql.Data.MySqlClient;

string connectionString = "server=localhost;port=3306;database=geodb;user=s;password=1234567;";

// 2. Создаем объект подключения в блоке using для автоматического закрытия
using (MySqlConnection connection = new MySqlConnection(connectionString))
{
    connection.Open();

    string sqlQuery = "SELECT name, surname FROM users";
    
    using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
    {
        using (MySqlDataReader reader = command.ExecuteReader())
        {
            // while (reader.Read())
            // {
            //     string name = reader.GetString("name");
            //     string surname = reader.GetString("surname");

            //     Console.WriteLine($"Name: {name}, Surname: {surname}");
            // }
            Console.WriteLine(connection.ServerVersion);
        }
    }
}