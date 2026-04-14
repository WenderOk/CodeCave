using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_04
{
    internal class Program
    {
        public delegate void VoidDelegate();
        public delegate void StringDelegate(string str);
        public delegate T NumberDelegate<T, K>(T a, K b);

        public static void TurnLights() => Console.WriteLine("Lights on");
        public static void PrintHello() => Console.WriteLine("Hello!");
        public static void StartServer() => Console.WriteLine("Server started");


        public static void ConsoleLog(string message) => Console.WriteLine($"[LOG]: {message}");
        public static void SendEmail(string address) => Console.WriteLine($"Email sent to {address}");
        public static void Print(string str) => Console.WriteLine(str);


        public static double GetSum(double a, int b) => a + b;
        public static double Mult(double a, double b) => a * b;
        public static int Max(int a, int b) => a > b ? a : b;



        static void Main(string[] args)
        {
            VoidDelegate vd = TurnLights;
            vd += PrintHello;
            vd += StartServer;
            vd.Invoke();

            Console.WriteLine();

            StringDelegate sd = ConsoleLog;
            sd.Invoke("Some info");
            sd -= ConsoleLog;
            sd += SendEmail;
            sd.Invoke("example@email.com");
            sd -= SendEmail;
            sd += Print;
            sd.Invoke("Hello world!");

            Console.WriteLine();

            NumberDelegate<double, int> nd1 = GetSum;
            Console.WriteLine(nd1.Invoke(2, 3));
            NumberDelegate<double, double> nd2 = Mult;
            Console.WriteLine(nd2.Invoke(1.5, 2.75));
            NumberDelegate<int, int> nd3 = Max;
            Console.WriteLine(nd3.Invoke(5, 45));
        }
    }
}
