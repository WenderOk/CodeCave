using System;
using MySql.Data.MySqlClient;

namespace databaseManager
{
    public class DatabaseManager
    {
        private static string connectionString = "server=localhost;port=3306;database=geodb;user=s;password=1234567;CharSet=utf8mb4;";

        public static void DisplayUsersWithFilter(string? groupId)
        {
            string whereOption = " ";
            if (groupId != "0" && !string.IsNullOrEmpty(groupId))
                whereOption = $"where g.id = {groupId} ";

            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string sqlQuery = $@"
                SELECT 
                    u.surname, u.name, u.patronomic, u.username, u.password, u.birth_date, 
                    g.name as group_name, a.country, a.city, a.street
                FROM users u
                inner join users_groups g on u.group_id = g.id
                inner join addresses a on u.address_id = a.id
                {whereOption};";

            using MySqlCommand command = new MySqlCommand(sqlQuery, connection);
            using MySqlDataReader reader = command.ExecuteReader();
            
            for (int i = 0; i < 10; i++)
                Console.Write($"{reader.GetName(i).PadRight(15)} |  ");
            Console.WriteLine("\n" + new string('-', 178) + "| ");

            while (reader.Read())
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i == 5 && reader.GetFieldType(i) == typeof(DateTime))
                        Console.Write($"{reader.GetDateTime(i).ToString("dd-MM-yyyy").PadRight(15)} |  ");
                    else
                        Console.Write($"{reader[i]?.ToString()?.PadRight(15)} |  ");
                }
                Console.WriteLine();
            }
        }

 
        public static void AddUser(string? surname, string? name, string? patronomic, string? username, 
                                   string? password, DateTime? birthDate, int? groupId, 
                                   string? country, string? city, string? street, int? houseNumber)
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            using MySqlTransaction transaction = connection.BeginTransaction();

            try
            {
                int addressId;

                string insertAddressQuery = @"
                    INSERT INTO addresses (country, city, street, house_number)
                    VALUES (@country, @city, @street, @house_number);
                    SELECT LAST_INSERT_ID();";

                using (MySqlCommand addressCmd = new MySqlCommand(insertAddressQuery, connection, transaction))
                {
                    addressCmd.Parameters.AddWithValue("@country", country ?? (object)DBNull.Value);
                    addressCmd.Parameters.AddWithValue("@city", city ?? (object)DBNull.Value);
                    addressCmd.Parameters.AddWithValue("@street", street ?? (object)DBNull.Value);
                    addressCmd.Parameters.AddWithValue("@house_number", houseNumber == 0 ? DBNull.Value : (object)houseNumber);

                    var result = addressCmd.ExecuteScalar();
                    addressId = Convert.ToInt32(result);
                }

                string insertUserQuery = @"
                    INSERT INTO users (surname, name, patronomic, username, password, birth_date, group_id, address_id)
                    VALUES (@surname, @name, @patronomic, @username, @password, @birth_date, @group_id, @address_id)";

                using (MySqlCommand userCmd = new MySqlCommand(insertUserQuery, connection, transaction))
                {
                    userCmd.Parameters.AddWithValue("@surname", surname ?? (object)DBNull.Value);
                    userCmd.Parameters.AddWithValue("@name", name ?? (object)DBNull.Value);
                    userCmd.Parameters.AddWithValue("@patronomic", patronomic ?? (object)DBNull.Value);
                    userCmd.Parameters.AddWithValue("@username", username); // NOT NULL
                    userCmd.Parameters.AddWithValue("@password", password ?? (object)DBNull.Value);
                    
                    userCmd.Parameters.AddWithValue("@birth_date", birthDate.HasValue ? (object)birthDate.Value : DBNull.Value);
                    
                    userCmd.Parameters.AddWithValue("@group_id", groupId == 0 ? DBNull.Value : (object)groupId);
                    
                    userCmd.Parameters.AddWithValue("@address_id", addressId);

                    userCmd.ExecuteNonQuery();
                }

                transaction.Commit();
                Console.WriteLine("User successefully added!");
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine($"Error while adding user: {ex.Message}");
            }
        }
    }
}