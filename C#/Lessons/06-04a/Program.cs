using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_04a
{
    internal class Program
    {
        public class DataTime
        {
            public string ToShortDateString()
            { }
        }

        public class MyException : ApplicationException
        {
            public DataTime InputDate { get; }
            
            public MyException(DataTime date) : base($"Date {date.ToShortDateString()}")
            {
                InputDate = date;
            }
            public static void validateDate(DateTime date)
            {

            }
        }

        public class MyEx3 : ApplicationException
        {
            public MyEx3
        }

        static void Main(string[] args)
        {
            int num1, num2;
            double result;
            Console.WriteLine("Enter 2 numbers:");
            try
            {
                num1 = int.Parse(Console.ReadLine());
                num2 = int.Parse(Console.ReadLine());
                if(num2 == 0) throw new DivideByZeroException();
                result = (double)num1 / num2;
                Console.WriteLine($"Result: {result}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
