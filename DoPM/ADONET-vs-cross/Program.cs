using MySql.Data.MySqlClient;
using Microsoft.Data.Sqlite;
using System;
using System.IO;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

Console.WriteLine("Choose DB to connect:\n"
                    + " 1. MySQL\n"
                    + " 2. SQLite");
int choice = int.Parse(Console.ReadLine());

string connOpt = (choice == 1) ? "MySqlConnection" : "SqliteConnection";

var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

IConfiguration config = builder.Build();

switch(choice)
{
    case 1:
    {
        string connectionString = config.GetConnectionString(connOpt);

        using MySqlConnection connection = new MySqlConnection(connectionString);
        connection.Open();

        string sqlQuery = "SELECT name, surname FROM users";

        using MySqlCommand command = new MySqlCommand(sqlQuery, connection);

        Console.WriteLine(connection.ServerVersion);
        break;
    }
        
    case 2:
    {
        string connectionString = config.GetConnectionString(connOpt);

        using SqliteConnection connection = new SqliteConnection(connectionString);
        connection.Open();

        string sqlQuery = @"insert into students values(1, 'Test', 'Testov', 'some@main.ru');";

        using SqliteCommand command = new SqliteCommand(sqlQuery, connection);

        command.ExecuteNonQuery();

        Console.WriteLine(connection.ServerVersion);
        break;
    }
    default:
        Console.WriteLine("Wrong option");
        break;
    
}




public class AppConfig
{
    public string? ConnectionString { get; set; }
}