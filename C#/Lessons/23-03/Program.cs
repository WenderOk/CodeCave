using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prog2;
using Animals;

namespace _23_03
{
    internal class Program
    {
        class Book
        {
            public string name;
            public double price;

            public override string ToString()
            {
                return base.ToString();
            }
        }

        class Shop
        {
            public Book[] books;
            public double cost;
        }


        static void Main(string[] args)
        {
            Cat c = new Cat();
            c.say();
        }
    }
}
