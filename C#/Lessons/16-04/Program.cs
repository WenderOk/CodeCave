using System;
using System.Collections.Generic;
using System.Linq;

namespace _16_04
{
    public delegate void Exam_Delegate(string m);
    public enum Enum_Subject { Math = 1, Physics, Programming }

    public class Student
    {
        private static Random rnd = new Random();
        public string Name { get; set; }
        public Enum_Subject Exam_Name { get; set; }
        public int Procant_Done_Homework { get; set; }
        public bool IsDopusk { get; set; }
        public int Exam_Mark { get; set; }

        public Student(string name, Enum_Subject exam_name)
        {
            this.Name = name;
            this.Exam_Name = exam_name;
            this.Procant_Done_Homework = rnd.Next(0, 101);
            this.IsDopusk = this.Procant_Done_Homework > 60;
        }
    }

    public class Exam
    {
        private static Random rnd = new Random();
        private Enum_Subject _subject;

        public Exam(Enum_Subject subject) => _subject = subject;

        public void StartGroupExam(List<Student> students, Exam_Delegate notify)
        {
            var group = students.Where(s => s.Exam_Name == _subject && s.IsDopusk).ToList();

            if (group.Count > 0)
            {
                notify?.Invoke($"\n>>> ЭКЗАМЕН: {_subject} <<<");
                foreach (var s in group)
                {
                    s.Exam_Mark = rnd.Next(2, 6);
                    string status = s.Exam_Mark == 2 ? "Пересдача" : "Сдал";
                    notify?.Invoke($"Студент: {s.Name,-7} | Оценка: {s.Exam_Mark} ({status})");
                }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student("Иван", Enum_Subject.Math),
                new Student("Анна", Enum_Subject.Math),
                new Student("Денис", Enum_Subject.Physics),
                new Student("Марина", Enum_Subject.Physics),
                new Student("Олег", Enum_Subject.Programming)
            };

            // 1. Список НЕ допущенных
            Console.WriteLine("=== НЕ ДОПУЩЕНЫ (ДЗ <= 60%) ===");
            students.Where(s => !s.IsDopusk).ToList()
                    .ForEach(s => Console.WriteLine($"{s.Name} - {s.Procant_Done_Homework}%"));

            // 2. Список ДОПУЩЕННЫХ
            Console.WriteLine("\n=== СПИСОК ДОПУЩЕННЫХ К СЕССИИ ===");
            students.Where(s => s.IsDopusk).ToList()
                    .ForEach(s => Console.WriteLine($"{s.Name} [{s.Exam_Name}] - ДЗ: {s.Procant_Done_Homework}%"));

            // 3. Проведение экзаменов
            foreach (Enum_Subject sub in Enum.GetValues(typeof(Enum_Subject)))
            {
                Exam exam = new Exam(sub);
                exam.StartGroupExam(students, Console.WriteLine);
            }

            Console.ReadKey();
        }
    }
}
