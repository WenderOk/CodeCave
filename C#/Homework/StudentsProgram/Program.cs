using System;

public class Student
{
    public string Name { get; }
    private string[] subjects;
    private int[][] grades;

    public Student(string name, string[] subjects)
    {
        Name = name;
        this.subjects = subjects;
        grades = new int[subjects.Length][];
        for (int i = 0; i < subjects.Length; i++)
            grades[i] = new int[0];
    }

    public void AddGrade(string subjectName, int grade)
    {
        int index = Array.IndexOf(subjects, subjectName);
        if (index == -1)
            throw new ArgumentException("Предмет не найден");
        AddGrade(index, grade);
    }

    public void AddGrade(int subjectIndex, int grade)
    {
        if (subjectIndex < 0 || subjectIndex >= subjects.Length)
            Console.WriteLine("Неверный индекс предмета");

        int[] current = grades[subjectIndex];
        int[] newArray = new int[current.Length + 1];
        Array.Copy(current, newArray, current.Length);
        newArray[current.Length] = grade;
        grades[subjectIndex] = newArray;
    }

    public double GetAverageGrade(string subjectName)
    {
        int index = Array.IndexOf(subjects, subjectName);
        if (index == -1)
            throw new ArgumentException("Предмет не найден");
        return GetAverageGrade(index);
    }

    public double GetAverageGrade(int subjectIndex)
    {
        if (subjectIndex < 0 || subjectIndex >= subjects.Length)
            Console.WriteLine("Неверный индекс предмета");

        int[] current = grades[subjectIndex];
        if (current.Length == 0)
            return 0;
        double sum = 0;
        foreach (int g in current)
            sum += g;
        return sum / current.Length;
    }

    public double[] GetAllAverages()
    {
        double[] avgs = new double[subjects.Length];
        for (int i = 0; i < subjects.Length; i++)
            avgs[i] = GetAverageGrade(i);
        return avgs;
    }

    public string[] Subjects => subjects;
}

namespace StudentsProgram
{
    internal class Program
    {
        static void Main()
        {
            string[] subjects = { "Математика", "С#", "Информатика", "Python" };

            Student[] students = new Student[]
            {
                new Student("Сева", subjects),
                new Student("Некита", subjects),
                new Student("Лео", subjects)
            };

            students[0].AddGrade("Математика", 4);
            students[0].AddGrade("Математика", 5);
            students[0].AddGrade("С#", 3);
            students[1].AddGrade("Информатика", 5);
            students[1].AddGrade("Информатика", 5);
            students[2].AddGrade("Python", 4);

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n=== Список студентов ===");
                for (int i = 0; i < students.Length; i++)
                    Console.WriteLine($"{i + 1}. {students[i].Name}");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите студента (номер): ");

                string input = Console.ReadLine();
                if (int.TryParse(input, out int choice) && choice >= 0 && choice <= students.Length)
                {
                    if (choice == 0)
                    {
                        exit = true;
                    }
                    else
                    {
                        Student current = students[choice - 1];
                        StudentMenu(current);
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                }
            }
        }

        static void StudentMenu(Student student)
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine($"\n--- Студент: {student.Name} ---");
                Console.WriteLine("1. Просмотреть средние оценки по всем предметам");
                Console.WriteLine("2. Просмотреть среднюю оценку по конкретному предмету");
                Console.WriteLine("3. Добавить оценку");
                Console.WriteLine("0. Вернуться к списку студентов");
                Console.Write("Выберите действие: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        ShowAllAverages(student);
                        break;
                    case "2":
                        ShowSubjectAverage(student);
                        break;
                    case "3":
                        AddGradeToStudent(student);
                        break;
                    case "0":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Неверный пункт меню.");
                        break;
                }
            }
        }

        static void ShowAllAverages(Student student)
        {
            Console.WriteLine("Средние оценки:");
            for (int i = 0; i < student.Subjects.Length; i++)
            {
                double avg = student.GetAverageGrade(i);
                Console.WriteLine($"{student.Subjects[i]}: {avg:F2}");
            }
        }

        static void ShowSubjectAverage(Student student)
        {
            Console.WriteLine("Доступные предметы:");
            for (int i = 0; i < student.Subjects.Length; i++)
                Console.WriteLine($"{i + 1}. {student.Subjects[i]}");

            Console.Write("Выберите номер предмета: ");
            if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 1 && idx <= student.Subjects.Length)
            {
                double avg = student.GetAverageGrade(idx - 1);
                Console.WriteLine($"Средняя оценка по предмету {student.Subjects[idx - 1]}: {avg:F2}");
            }
            else
            {
                Console.WriteLine("Неверный номер предмета.");
            }
        }

        static void AddGradeToStudent(Student student)
        {
            Console.WriteLine("Доступные предметы:");
            for (int i = 0; i < student.Subjects.Length; i++)
                Console.WriteLine($"{i + 1}. {student.Subjects[i]}");

            Console.Write("Выберите номер предмета: ");
            if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 1 && idx <= student.Subjects.Length)
            {
                Console.Write("Введите оценку (1-5): ");
                string input = Console.ReadLine();
                int grade = int.Parse(input);
                if (grade >= 1 && grade <= 5)
                {
                    student.AddGrade(idx - 1, grade);
                    Console.WriteLine("Оценка добавлена.");
                }
                else
                {
                    Console.WriteLine("Оценка должна быть целым числом от 1 до 5.");
                }
            }
            else
            {
                Console.WriteLine("Неверный номер предмета.");
            }
        }
    }
}