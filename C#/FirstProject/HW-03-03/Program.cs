using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETApp
{
    internal class Program
    {
        public class Student
        {
            public string Name, Surname, Patronymic;

        }

        public class MyClass
        {
            public int number;
            public string name;
            public bool IsStudent;

            public MyClass() { }
            public MyClass(int nP)
            {
                number = nP;
                name = "aboab";
                IsStudent = true;
            }
            public MyClass(int nP, string sP)
            {
                number = nP;
                name = sP;
                IsStudent = true;
            }
            public MyClass(int nP, string sP, bool bP)
            {
                number = nP;
                name = sP;
                IsStudent = bP;
            }

            public void Print()
            {
                Console.WriteLine($"number = {number}, name = {name}, isStudent = {IsStudent}");
            }


        }

        static void Main(string[] args)
        {
            MyClass cl1 = new MyClass(12);
            MyClass cl2 = new MyClass(143, "hello");
            MyClass cl3 = new MyClass(143, "hello", false);
            MyClass cl4 = new MyClass();

            cl1.Print();
            cl2.Print();
            cl3.Print();
            cl4.Print();

        }
    }
}


