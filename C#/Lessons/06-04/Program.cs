using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;


namespace _06_04
{
    internal class Program
    {
        public class Student<T>
        {
            public T Id { get; set; }
            public string Name { get; set; }
            public Student(T id, string name) 
            {
                Id = id;
                Name = name;
            }
            public override string ToString()
            {
                return $"ID: {Id} Name: {Name}";
            }
        }

        public class Group : IEnumerator
        {
            public string GroupName { get; set; }
            private int position = -1;
            public Student<int>[] Students { get; set; }

            public Group(string name)
            {
                GroupName = name;
                Students = new Student<int>[]
                {
                    new Student<int>(1, "Seva"),
                    new Student<int>(2, "Leo"),
                    new Student<int>(3, "ABoab"),
                    new Student<int>(4, "Kseroks")
                };
            }
            public object Current
            {
                get
                {
                    if (position < 0 || position >= Students.Length)
                        throw new InvalidOperationException();
                    return Students[position];
                }
            }
            public bool MoveNext()
            {
                position++;
                return position < Students.Length;
            }

            public void Reset()
            {
                position = -1;
            }

        }

        public class Group2 : IEnumerable
        {
            public string GroupName { get; set; }
            public Student<int>[] Students { get; set; }

            public Group2(string name)
            {
                GroupName = name;
                Students = new Student<int>[]
                {
                    new Student<int>(1, "Seva"),
                    new Student<int>(2, "Leo"),
                    new Student<int>(3, "ABoab"),
                    new Student<int>(4, "Kseroks")
                };
            }

            public IEnumerator GetEnumerator()
            {
                return ((IEnumerable<Student<int>>)Students).GetEnumerator();
            }
        }

        static void Main(string[] args)
        {
            Group g1 = new Group("RPO");
            while(g1.MoveNext())
            { Console.WriteLine(g1.Current); }

            Group2 g2 = new Group2("KGID");
            foreach(Student<int> item in g2)
            { Console.WriteLine(item); }
            Console.ReadKey();
        }
    }
}
