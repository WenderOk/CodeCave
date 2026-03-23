using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace square
{
    public class figure
    {
        public int x { get; set; }
        public int y { get; set; }

        public override string ToString()
        {
            return $"Width: {x}, Height: {y}";
        }
    }

}
namespace rectangle
{
    public class figure
    {
        public int x { get; set; }
        public int y { get; set; }

        public override string ToString()
        {
            return $"Width: {x}, Height: {y}";
        }
    }
}


namespace CW_03_03
{
    internal class Program
    {
        public class Car
        {
            public string mark { get; set; }
            public string country { get; set; }
            public string color { get; set; }
            public int year { get; set; }

            public Car(string maP, string couP, string colP, int yearP)
            {
                mark = maP;
                country = couP;
                color = colP;
                year = yearP;
            }

            public override string ToString()
            {
                return $"Mark: {mark}\nCountry: {country}\nColor: {color}\nYear: {year}";
            }
        }

        public class Person
        {
            public string name { get; set; }

            public Person(string Name) { name = Name; }

            public virtual void Print()
            {
                Console.WriteLine($"Name: {name}");
            }
        }

        public class Student : Person
        {
            public int class_number { get; set; }

            public Student(string nameP, int num) : base(name)
            {
                class_number = num;
            }

            public override void Print()
            {
                base.Print();
                Console.WriteLine($"Class: {class_number}");
            }
        }
        public class Teacher : Student
        {
            public string Subject { get; set; }
            public Teacher(string nameP, string subP) : base(name)
            {
                Subject = subP;
            }
            public override void Print()
            {
                Console.WriteLine($"subject: {Subject}");
            }
        }

        static void Main(string[] args)
        {
            //Bank b1 = new Bank("ASD");
            //Bank b2 = new Bank("ZXC");

            //b1.changeBalance(1000, "Seva", "goy");
            //b2.changeBalance(-450, "Egor", "sigma");
            //PrintBalance();

            //Car cr = new Car("asd", "USA", "red", 1999);
            //Console.WriteLine(cr);

            Teacher tch = new Teacher("Vova", 12, 43);
            tch.Print();
        }
    }

    //public class Bank
    //{
    //    public string Name;
    //    static private int money;

    //    public Bank() { }
    //    public Bank(string nameP) { Name = nameP; }
    //    static Bank() { money = 1000000; }

    //    public void changeBalance(int amount, string name, string comment)
    //    {
    //        Console.WriteLine("User: " + name + " " + comment + " sum: " + amount);
    //        money += amount;

    //    }

    //    public static void PrintBalance() { Console.WriteLine("Money sum: " + money); }

    //    public class Sweets
    //    {
    //        public static int Number = 100;
    //        public void Print() { Console.WriteLine("Number" + Number); }
    //    }
    //}

 
 }
