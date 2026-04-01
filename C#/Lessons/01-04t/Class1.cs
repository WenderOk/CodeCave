using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_04t
{
    internal class Class1
    {
        public class Student
        {
            public string Name {  get; set; }
            public int Age { get; set; }
            public Student(string name, int age)
            {
                Name = name;
                Age = age;
            }

            public override string ToString()
            {
                return $"{Name}, {Age}";
            }

            public class Group
            {
                public Group() { }
                public Student[] students =
                    {
                    new Student("Biba", 15),
                    new Student("Asd", 16),
                    new Student("Qwerty", 55),
                    new Student("Abob", 35),
                };
            }
        }

    }
}
