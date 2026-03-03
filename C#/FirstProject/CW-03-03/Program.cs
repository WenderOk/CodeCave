using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW_03_03
{
    internal class Program
    {
        public class Bank
        {
            public string Name;
            static private int money;

            public Bank() { }
            public Bank(string nameP) { Name = nameP; }
            static Bank() { money = 1000000; }

            public void changeBalance(int amount, string name, string comment)
            {
                Console.WriteLine("User: " + name + " " + comment + " sum: " + amount);
                money += amount;

            }

            public static void PrintBalance() { Console.WriteLine("Money sum: " + money); }


            public class Sweets
            {
                public static int Number = 100;
                public void Print() { Console.WriteLine("Number" + Number); }
            }

            static void Main(string[] args)
            {
                Bank b1 = new Bank("ASD");
                Bank b2 = new Bank("ZXC");

                b1.changeBalance(1000, "Seva", "goy");
                b2.changeBalance(-450, "Egor", "sigma");
                PrintBalance();


                //Sweets sweets1 = new Sweets();
                //Sweets sweets2 = new Sweets();

                //Sweets.Number += 200;
                //sweets1.Print();
                //sweets2.Print();
            }
        }
    }
}
