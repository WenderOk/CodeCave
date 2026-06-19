using System;
using Npgsql;

string connectionString = "Host=ep-proud-pine-asktl1e9-pooler.c-4.eu-central-1.aws.neon.tech; Database=neondb; Username=neondb_owner; Password=npg_IN1GRHu3Fdrk; SSL Mode=VerifyFull; Channel Binding=Require;";

using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
{
    connection.Open();

    string sqlQuery = "SELECT name, surname FROM users";

    using NpgsqlCommand command = new NpgsqlCommand(sqlQuery, connection);

    Console.WriteLine(connection.ServerVersion);

}