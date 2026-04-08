using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_04_Money
{
    public class Money
    {
        public int Rubs;
        public int Cents;

        public Money(int rubs, int cents)
        {
            Rubs = rubs;
            Cents = cents;
        }

        public override bool Equals(object obj)
        { return ToString() == obj.ToString(); }

        public override int GetHashCode()
        { return ToString().GetHashCode(); }

        public static Money operator++(Money m)
        {
            int sum = m.Rubs * 100 + m.Cents;
            ++sum;
            return new Money(sum / 100, sum % 100);
        }

        public static Money operator--(Money m)
        {
            int sum = m.Rubs * 100 + m.Cents;
            try
            {
                if ((sum - 1) < 0)
                    throw new MoneyOperationException(m);
                --sum;
            }
            catch (MoneyOperationException)
            {
                //Console.WriteLine(ex.Message);
                throw;
            }
            return new Money(sum / 100, sum % 100);
        }

        public static Money operator+(Money m1, Money m2)
        {
            int sum1 = m1.Rubs * 100 + m1.Cents;
            int sum2 = m2.Rubs * 100 + m2.Cents;
            return new Money((sum1+sum2)/100, (sum1 + sum2) % 100);
        }

        public static Money operator-(Money m1, Money m2)
        {
            int sum1 = m1.Rubs * 100 + m1.Cents;
            int sum2 = m2.Rubs * 100 + m2.Cents;
            try
            {
                if((sum1 - sum2) < 0)
                    throw new MoneyOperationException(m1, m2);
            }
            catch (MoneyOperationException)
            {
                //Console.WriteLine(ex.Message);
                throw;
            }
            return new Money((sum1 - sum2) / 100, (sum1 - sum2) % 100);
        }

        public static Money operator/(Money m, int value)
        {
            int sum = m.Rubs * 100 + m.Cents;
            sum /= value;
            return new Money(sum / 100, sum % 100);
        }

        public static Money operator*(Money m, int value)
        {
            int sum = m.Rubs * 100 + m.Cents;
            sum *= value;
            return new Money(sum / 100, sum % 100);
        }

        public static bool operator==(Money m1, Money m2)
        { return m1.Equals(m2); }

        public static bool operator!=(Money m1, Money m2)
        { return !m1.Equals(m2); }

        public static bool operator>(Money m1, Money m2)
        {
            int sum1 = m1.Rubs * 100 + m1.Cents;
            int sum2 = m2.Rubs * 100 + m2.Cents;
            return sum1 > sum2;
        }

        public static bool operator<(Money m1, Money m2)
        {
            int sum1 = m1.Rubs * 100 + m1.Cents;
            int sum2 = m2.Rubs * 100 + m2.Cents;
            return sum1 < sum2;
        }

        public override string ToString()
        { return $"{Rubs}.{Cents}"; }
    }

    public class MoneyOperationException: ApplicationException
    {
        public MoneyOperationException(Money m1, Money m2):
            base($"Operation aborted!: not enough money. {m1} - {m2}!") { }
        public MoneyOperationException(Money m) :
            base($"Operation aborted!: not enough money. Current value: {m}!")
        { }

    }

    public interface ILogable
    {
        void Log(string message);
        void ErrorLog(string message);
    }

    public class ConsoleLogger : ILogable
    {
        public void ErrorLog(string message)
        { Console.WriteLine($"{DateTime.Now} [ERROR]: {message}"); }

        public void Log(string message)
        { Console.WriteLine($"{DateTime.Now} [INFO]: {message}"); }
    }

    public class FileLogger : ILogable
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

    public class MoneyManager
    {
        private readonly ILogable logger;
        public MoneyManager(ILogable logger)
        { this.logger = logger; }

        public Money Add(Money m1, Money m2)
        {
            logger.Log($"Added {m1} to {m2}");
            return m1 + m2;
        }

        public Money Substract(Money m1, Money m2)
        {
            try
            {
                logger.Log($"Substracting {m2} from {m1}...");
                return m1 - m2;
            }
            catch (MoneyOperationException ex)
            {
                logger.ErrorLog(ex.Message);
                return null;
            }
        }

        public Money Div(Money m, int value)
        {
            logger.Log($"{m} divided by {value}");
            return m / value;
        }

        public Money Mult(Money m, int value)
        {
            logger.Log($"{m} multiplyed on {value}");
            return m * value;
        }

        public Money Increment(Money m)
        {
            logger.Log($"{m} incremented");
            return ++m;
        }

        public Money Decrement(Money m)
        {
            try
            {
                logger.Log($"decrementing {m}");
                return --m;
            }
            catch (MoneyOperationException ex)
            {
                logger.ErrorLog(ex.Message);
                return null;
            }
        }
    }

    public class Task
    {
        public void run()
        {
            ConsoleLogger logger = new ConsoleLogger();
            MoneyManager mngr = new MoneyManager(logger);
            Money m1 = new Money(0, 0);
            Money m2 = new Money(12, 5);
            Money m3 = new Money(5, 9);


            // Для логирования операций пришлось создать менеджер с собственными методами
            // и если выполнять операцию без менеджера, то программа вылетит в нео исключение

            Console.WriteLine("Result: " + mngr.Substract(m2, m3));
            Console.WriteLine("Result: " + mngr.Decrement(m3));
            Console.WriteLine("Result: " + mngr.Substract(m1, m2));
            Console.WriteLine("Result: " + mngr.Decrement(m1));
            Console.WriteLine("Result: " + mngr.Increment(m3));
            Console.WriteLine("Result: " + mngr.Mult(m2, 2));
            Console.WriteLine("Result: " + mngr.Div(m2, 2));
            Console.WriteLine("Result: " + mngr.Add(m3, m2));
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Task t = new Task();
            t.run();
        }
    }
}
