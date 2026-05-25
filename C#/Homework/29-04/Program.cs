using System;
using System.Threading;

namespace _29_04
{
    public delegate void RaceEventHandler(string message);

    public class SportsCarRace
    {
        public event RaceEventHandler OnStart;
        public event RaceEventHandler OnProgress;
        public event RaceEventHandler OnFinish;

        public void Run()
        {
            OnStart?.Invoke("Sport cars on start!");

            for (int i = 1; i <= 5; i++)
            {
                Thread.Sleep(500);
                OnProgress?.Invoke($"Sport cars on track... stage {i}/5");
            }

            OnFinish?.Invoke("Sport cars have reached finish!");
        }
    }

    public class Task
    {
        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== RACING MENU =====");
                Console.WriteLine("1. Sports Car Race");
                Console.WriteLine("2. Passenger Car Race (stub)");
                Console.WriteLine("3. Truck Race (stub)");
                Console.WriteLine("4. Bus Race (stub)");
                Console.WriteLine("0. Exit");
                Console.Write("Your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        SportsCarRace race = new SportsCarRace();
                        race.OnStart += (msg) => Console.WriteLine(msg);
                        race.OnProgress += (msg) => Console.WriteLine(msg);
                        race.OnFinish += (msg) => Console.WriteLine(msg);

                        Console.WriteLine("\n=== RACE STARTED ===");
                        race.Run();
                        Console.WriteLine("=== RACE FINISHED ===\n");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;

                    case "2":
                        Console.WriteLine("\n[Stub] Passenger car races are not implemented yet.\n");
                        Console.WriteLine("Press any key...");
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.WriteLine("\n[Stub] Truck races are not implemented yet.\n");
                        Console.WriteLine("Press any key...");
                        Console.ReadKey();
                        break;

                    case "4":
                        Console.WriteLine("\n[Stub] Bus races are not implemented yet.\n");
                        Console.WriteLine("Press any key...");
                        Console.ReadKey();
                        break;

                    case "0":
                        Console.WriteLine("Exiting program...");
                        return;

                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        Thread.Sleep(1000);
                        break;
                }
            }
        }
    }

    internal class Program
    {
        static void Main()
        {
            Task t = new Task();
            t.Run();
        }
    }
}
