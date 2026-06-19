using MySql.Data.MySqlClient;
using databaseManager;

namespace program
{
    partial class Program()
    {
        public static void Main()
        {
            int? choice;

            Console.WriteLine(""" 
            Choice what do you eanna do: 
                1. Display users
                2. Add user
                3. Edit user
                4. Delete user
                0. exit
            """);

            choice = int.Parse(Console.ReadLine());  

            switch (choice)
            {
                case 0:
                {
                    Environment.Exit(0);
                    break;
                }
                case 1:
                {
                    Console.Write("""
                    0. All users
                    1. moderator
                    2. user
                    3. admin
                    Enter group id: 
                    """);
                    string? id = Console.ReadLine();
                    DatabaseManager.DisplayUsersWithFilter(id);
                    break;
                }
                case 2:
                {
                    Console.Write("Введите фамилию: ");
                    string? surname = Console.ReadLine();

                    Console.Write("Введите имя: ");
                    string? name = Console.ReadLine();

                    Console.Write("Введите отчество (если есть): ");
                    string? patronymic = Console.ReadLine();

                    Console.Write("Введите логин (username): ");
                    string? username = Console.ReadLine();

                    Console.Write("Введите пароль: ");
                    string? password = Console.ReadLine();

                    Console.Write("Введите дату рождения (ДД.ММ.ГГГГ) или нажмите Enter для пропуска: ");
                    string? birthDateInput = Console.ReadLine();
                    DateTime? birthDate = null;
                    if (!string.IsNullOrWhiteSpace(birthDateInput) && DateTime.TryParse(birthDateInput, out DateTime parsedDate))
                        birthDate = parsedDate;

                    int groupId;
                    while (true)
                    {
                        Console.Write("""
                    1. moderator
                    2. user
                    3. admin
                    Enter group id: 
                    """);
                        if (int.TryParse(Console.ReadLine(), out groupId)) break;
                        Console.WriteLine("Wrong input! Try again");
                    }

                    Console.Write("Enter country: ");
                    string country = Console.ReadLine();

                    Console.Write("Enter city: ");
                    string city = Console.ReadLine();

                    Console.Write("Enter street: ");
                    string street = Console.ReadLine();

                    int houseNumber;
                    while (true)
                    {
                        Console.Write("Enter house number (integer): ");
                        if (int.TryParse(Console.ReadLine(), out houseNumber)) break;
                        Console.WriteLine("Wrong input! Try again");
                    }

                    DatabaseManager.AddUser(surname, name, patronymic, username, password, birthDate, groupId, country, city, street, houseNumber);
                    break;
                }
                default:
                {
                    Console.WriteLine("Wrong option!");
                    break;
                }
            }
        }
    }
}

