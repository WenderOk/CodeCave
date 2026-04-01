using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using static _01_04t.Class1;

namespace _01_04t
{
    internal class Program
    {
        public interface ILogable
        {
            void Log(string message);
        }

        public class ConsoleLogger : ILogable
        {
            public void Log(string message)
            { Console.WriteLine(message); }
        }

        public class FileLogger : ILogable
        {
            public string path = "log.txt";

            public void Log(string message)
            {
                using (StreamWriter sw = new StreamWriter(path, true))
                { sw.WriteLine(message); }
            }
        }


        static void Main(string[] args)
        {
            //ILogable l1 = new ConsoleLogger();
            //ILogable l2 = new FileLogger();

            //l1.Log("Message in console");
            //l2.Log("Message to file");

            Group gr = new Group();



            Console.ReadKey();
        }
    }
}
