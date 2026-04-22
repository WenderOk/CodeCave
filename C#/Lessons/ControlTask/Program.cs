using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace ControlTask
{
    public delegate void Work_process_Delegate(string message);

    public interface ILogger
    {
        void Log(string message);
        void ErrorLog(string message);
    }

    public class ConsoleLogger : ILogger
    {
        public void ErrorLog(string message)
        { Console.WriteLine($"{DateTime.Now} [ERROR]: {message}"); }

        public void Log(string message)
        { Console.WriteLine($"{DateTime.Now} [INFO]: {message}"); }
    }

    public class FileLogger : ILogger
    {
        private readonly string path = "Log.txt";
        public void ErrorLog(string message)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine($"{DateTime.Now} [ERROR]: {message}");
                writer.Close();
            }
        }

        public void Log(string message)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine($"{DateTime.Now} [INFO]: {message}");
                writer.Close();
            }
        }
    }
    [Serializable]
    public class Address
    {
        public string City;
        public string Street;
        public int HouseNumber;

        public Address() { }
        public Address(string city, string street, int houseNumber)
        {
            City = city;
            Street = street;
            HouseNumber = houseNumber;
        }

        public override string ToString()
        {
            return $"{City}, {Street}, {HouseNumber}";
        }
    }

    public class Base
    {
        public string OrgName { get; set; }
        public string FilName { get; set; }
        public string FilCityName { get; set; }

        public Base() { }
        public Base(string orgName, string filName, string filCityName)
        {
            OrgName = orgName;
            FilName = filName;
            FilCityName = filCityName;
        }
    }

    public class Person_card<T> : Base
    {
        public T Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Patronim { get; set; }

        public DateTime HireDate { get; set; }
        public int Category { get; set; }
        public Address HomeAddress { get; set; }

        public Person_card() { }
        public Person_card(string orgName, string filName, string filCityName, T id,  string secondName, string firstName, string patronim, DateTime hireDate, int category, Address homeAddress)
            : base(orgName, filName, filCityName)
        {

            Id = id;
            FirstName = firstName;
            SecondName = secondName;
            Patronim = patronim;
            HireDate = hireDate;
            Category = category;
            HomeAddress = homeAddress;
        }

        public override string ToString()
        {
            return $"Organisation name: {OrgName}\n" +
                   $"Filial name: {FilName}\n" +
                   $"Filial city name: {FilCityName}\n" +
                   $"ID: {Id}\n" +
                   $"Second name: {SecondName}\n" +
                   $"First name: {FirstName}\n" +                  
                   $"Patronim: {Patronim}\n" +
                   $"Hire date: {HireDate}\n" +
                   $"Category: {Category}\n" +
                   $"Home address: {HomeAddress}";
        }

        public void WorkStatus(string message)
        {
            string full_name = SecondName + " " + FirstName + " " + Patronim;
            Console.WriteLine($"{message} - {full_name} - \t{Category} категория  ");
        }
    }

    internal class Program
    {
        public class WorkersGroup
        {
            public event Work_process_Delegate ProcessEvent;
            public List<Person_card<int>> Cards { get; set; }
            public string path = "data.xml";
            public ILogger logger { get; set; }
            public FileService<int> fs { get; set; }
            public WorkersGroup()
            {
                logger = new FileLogger();
                fs = new FileService<int>(logger, path);
                if (File.Exists(path))
                { Cards = fs.LoadFromXml(path); }
                else
                { Cards = new List<Person_card<int>>(); }
            }

            public WorkersGroup(List<Person_card<int>> cards, ILogger logger)
            {
                Cards = cards;
                fs = new FileService<int>(logger, path);
            }

            public void printAllCards()
            {
                foreach (Person_card<int> card in Cards)
                    Console.WriteLine(card);
            }
            public Person_card<int> searchBySecondName(string sn)
            {
                return Cards.FirstOrDefault(c => c.SecondName == sn);
            }

            public Person_card<int> searchById(int id)
            {
                return Cards.FirstOrDefault(c => Equals(c.Id, id));
            }

            public void addCard(Person_card<int> card)
            {
                Cards.Add(card);
                fs.SaveToXml(Cards, path);
            }

            public void MainMenu(string path)
            {
                while (true)
                {
                    Console.WriteLine("M E N U");
                    Console.WriteLine("1. Редактировать список работников");
                    Console.WriteLine("2. Запустить проект");
                    Console.WriteLine("3. Выход ");
                    Console.ResetColor();
                    int choise;
                    if (int.TryParse(Console.ReadLine(), out choise))
                    {
                        switch (choise)
                        {
                            case 1:
                                {
                                    CardsMenu(path);
                                    break;
                                }
                            case 2:
                                {
                                    WorkMenu();
                                    break;
                                }
                            case 3:
                                {return; }
                        }
                    }

                }
            }
            public void WorkMenu()
            {
                foreach (Person_card<int> person in Cards)
                    ProcessEvent += person.WorkStatus;

                ProcessEvent?.Invoke("\nРаботник есть в штате");

                foreach (Person_card<int> person in Cards)
                    if (person.Category < 3)
                        ProcessEvent -= person.WorkStatus;

                ProcessEvent?.Invoke("\nРаботник принимает участие в проекте");

                foreach (Person_card<int> person in Cards)
                {
                    if (random.Next(50, 101) > 80)
                    { ProcessEvent -= person.WorkStatus; }
                }
               
                ProcessEvent?.Invoke("\nРаботник завершил проект\n");
                ProcessEvent?.Invoke("Работник получил премию\n");
            }
            public void CardsMenu(string path)
            {
                while (true)
                {
                    Console.WriteLine("M E N U");
                    Console.WriteLine("1. Вывести список работников");
                    Console.WriteLine("2. Найти по фамилии");
                    Console.WriteLine("3. Найти по ID");
                    Console.WriteLine("4. Добавить работника");
                    Console.WriteLine("5. Выход из режима");
                    Console.ResetColor();
                    int choise;
                    if (int.TryParse(Console.ReadLine(), out choise))
                    {
                        switch (choise)
                        {
                            case 1:
                            {
                                foreach (Person_card<int> person in Cards)
                                    Console.WriteLine(person + "\n");
                                break;
                            }
                            case 2:
                            {
                                Console.WriteLine("Введите фамилию: ");
                                string familia = Console.ReadLine();
                                var person = Cards.FirstOrDefault(p => p.SecondName == familia);

                                if (person != null)
                                { Console.WriteLine(person); }
                                else { Console.WriteLine("Работник не найден!"); }
                                break;
                            }
                            case 3:
                            {
                                Console.WriteLine("Введите ID: ");
                                int search_id;
                                if (int.TryParse(Console.ReadLine(), out search_id))
                                {
                                    var person = Cards.FirstOrDefault(p => p.Id == search_id);

                                    if (person != null)
                                    { Console.WriteLine(person); }
                                    else { Console.WriteLine("Работник не найден!"); }
                                }
                                break;
                            }
                            case 4:
                            {
                                int id, category, house;
                                string lname, fname, patronim, city, street;
                                DateTime d;
                                bool flag = true;
                                Console.WriteLine("Создание нового работника");
                                Console.WriteLine("Введите ID: ");
                                if (!int.TryParse(Console.ReadLine(), out id))
                                {
                                    Console.WriteLine("Ошибка ввода: ");
                                    flag = false;
                                }
                                else if(searchById(id) != null)
                                {
                                    Console.WriteLine("Рабочий с таким ID уже есть!");
                                    flag = false;
                                }

                                Console.WriteLine("Введите последовательно фамилию, имя, отчество: ");
                                lname = Console.ReadLine();
                                fname = Console.ReadLine();
                                patronim = Console.ReadLine();
                                Console.WriteLine("Введите дату приема на работу в формате дд-мм-гггг: ");
                                if (!DateTime.TryParse(Console.ReadLine(), out d))
                                {
                                    Console.WriteLine("Ошибка ввода!");
                                    flag = false;
                                }
                                Console.WriteLine("Введите категорию квалификации: ");
                                if (!int.TryParse(Console.ReadLine(), out category))
                                {
                                    Console.WriteLine("Ошибка ввода");
                                    flag = false;
                                }
                                Console.Write("Ввод прописки\nВведите город: ");
                                city = Console.ReadLine();
                                Console.Write("Введите название улицы: ");
                                street = Console.ReadLine();
                                Console.WriteLine("Введите номер дома: ");
                                if (!int.TryParse(Console.ReadLine(), out house))
                                {
                                    Console.WriteLine("Ошибка ввода");
                                    flag = false;
                                }
                                if (flag == true)
                                {
                                    Cards.Add(new Person_card<int>("Сева корпорация", "Юго-Восток",
                                        "Казань", id, lname, fname, patronim,
                                        new DateTime(d.Year, d.Month, d.Day), category,
                                        new Address(city, street, house)));
                                    fs.SaveToXml(Cards, path);
                                }
                                else Console.WriteLine("Работник не добавлен так как при вводе были допущены ошибки формата");
                                break;
                            }
                            case 5:
                            {
                                return;
                            }
                        }
                    }
                }
            }
        }

        public class FileService<T>
        {
            private readonly ILogger logger;
            private string path;
            public FileService(ILogger logger, string path)
            {
                this.logger = logger;
                this.path = path;
            }

            public void SaveToXml(List<Person_card<T>> Cards, string path)
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(Cards.GetType());
                    using (FileStream fs = new FileStream(path, FileMode.Create))
                    { serializer.Serialize(fs, Cards); }
                    logger.Log("File succefully saved!");
                }
                catch (Exception ex)
                { logger.ErrorLog(ex.Message); }
            }

            public List<Person_card<T>> LoadFromXml(string path)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Person_card<T>>));
                try
                {
                    using (FileStream fs = new FileStream(path, FileMode.Open))
                    {
                        logger.Log("File succefully loaded!");
                        return (List<Person_card<T>>)serializer.Deserialize(fs);
                    }
                }
                catch (Exception ex)
                {
                    logger.ErrorLog(ex.Message);
                    return null;
                }
            }
        }

        public static Random random { get; } = new Random();


            static void Main(string[] args)
            {
                WorkersGroup pr = new WorkersGroup();
                pr.MainMenu(pr.path);
                Console.ReadKey();
            }
    }
}
