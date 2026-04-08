using System;
using System.Collections.Generic;
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
            sum++;
            return new Money(sum / 100, sum % 100);
        }

        public static Money operator--(Money m)
        {
            int sum = m.Rubs * 100 + m.Cents;
            try
            {
                if ((sum-1) < 0)
                    throw new MoneyOperationException(m);
                sum--;
            }
            catch (MoneyOperationException ex)
            {
                Console.WriteLine(ex.Message);
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
            catch (MoneyOperationException ex)
            {
                Console.WriteLine(ex.Message);
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
        {
            return $"{Rubs}.{Cents}";
        }

    }

    public class MoneyOperationException: ApplicationException
    {
        public MoneyOperationException(Money m1, Money m2):
            base($"Nor enough money for operation. {m1.Rubs}.{m1.Cents} - {m2.Rubs}.{m2.Cents}\nOperation aborted!") { }
        public MoneyOperationException(Money m) :
            base($"Nor enough money for operation. {m.Rubs}.{m.Cents}\nOperation aborted!")
        { }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Money m1 = new Money(0, 0);
            Money m2 = new Money(12, 5);
            Console.WriteLine(m1);
            Console.WriteLine(m2);
            try
            {
                Money m3 = m1 - m2;
                m1--;
            }
            catch (MoneyOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            

        }
    }
}
