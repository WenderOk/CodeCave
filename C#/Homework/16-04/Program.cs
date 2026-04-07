using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_04
{

	public class DateNotNowException : ApplicationException
	{ 
		public DateNotNowException(string message) : base(message) { }
	}

	internal class Program
	{
        static void Main(string[] args)
		{
            while (true)
            {
                Console.Write("Enter todays date: ");
                string input = Console.ReadLine();
                try
                {
                    if (!DateTime.TryParse(input, out DateTime date))
                    {
                        Console.WriteLine("Incorrect date format!");
                        continue;
                    }

                    if (date != DateTime.Now.Date)
                        throw new DateNotNowException("Date is not equal to todays date!");
                    
                    Console.WriteLine("Date is correct");
                    break;

                }
                catch (DateNotNowException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            Console.ReadKey();
		}
	}
}
