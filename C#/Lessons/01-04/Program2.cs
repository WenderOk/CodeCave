using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace interf_1
{
    internal class Program
    {
        public interface ILogable
        {
            public void Log(string message);
        }

        public class ConsoleLogger : ILogable
        {
            public void Log(string message)
            { Console.WriteLine(message); }
        }

        public class FileLogger : ILogable
        {
            public string path = "C:\\log.txt";

            public void Log(string message)
            {
                using(StreamWriter sw = new StreamWriter(path, true))
                { sw.WriteLine(message); }
            }
        }
        

        static void Main(string[] args)
        {
            ILogable l1 = new ConsoleLogger();
            ILogable l2 = new FileLogger();

            Console.ReadKey();
        }
    }
}
