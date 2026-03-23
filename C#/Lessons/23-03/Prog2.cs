using System;
using System.Collections.Generic;

namespace Prog2
{
    public class Student
    {
        public int Id;
        public string Name;
        public string Surname;
        public string Patronomic;

    }
    public class StudentGroup
    {
        private List<Student> students = new List<Student>();
        public void AddStudent(Student student)
        { students.Add(student); }

        public Student this[int index]
        {
            get { return students[index]; }
            set { students[index] = value; }
        }

        //public Student this[string surname]
        //{
        //    get
        //    {
        //        foreach (Student student in students)
        //        {
        //            if (student.Surname == surname)
        //                return student;
        //        }
        //    }
        //}

        public void Print()
        {
            foreach (Student student in students)
            {
                Console.WriteLine($"{student.Id} {student.Name} {student.Surname} {student.Patronomic}");
            }
        }
    }
}
