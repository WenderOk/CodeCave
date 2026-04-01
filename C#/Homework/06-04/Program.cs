using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_04
{
    internal class Program
    {
        public interface ISend
        {
            void sendMes(string message);
        }

        public class Email : ISend
        {
            public void sendMes(string message)
            { Console.WriteLine($"\"{message}\" was sent by email"); }
        }
        public class Sms : ISend
        {
            public void sendMes(string message)
            { Console.WriteLine($"\"{message}\" was sent by sms"); }
        }


        static void Main(string[] args)
        {
            ISend s1 = new Email();
            ISend s2 = new Sms();
            s1.sendMes("Hello");
            s2.sendMes("Hello");

            //ISend s = { s1, s2 };
            //foreach (ISend spos in s)
            //{
            //    if (spos is Sms) { Console.ForegroundColor = ConsoleColor.Red; }
            //    if (spos is Email) { Console.ForegroundColor = ConsoleColor.Green; }
            //}

            object s3 = new Sms();
            ISend s4 = s3 as Sms;

            if (s4 != null)
            { Console.WriteLine("Success"); }
            else { Console.WriteLine("Fail"); }

            Console.ReadKey();

        }
    }
}
