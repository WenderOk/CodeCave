using System;

public struct LinearEquation
{
    public int A { get; }
    public int B { get; }

    public LinearEquation(int a, int b)
    {
        A = a;
        B = b;
    }

    public static LinearEquation My_Parse(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
            Console.WriteLine("Строка не может быть пустой.");

        string[] parts = s.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length != 2)
            Console.WriteLine("Строка должна содержать ровно два целых числа, разделённых пробелом.");

        if (!int.TryParse(parts[0], out int a) || !int.TryParse(parts[1], out int b))
            Console.WriteLine("Коэффициенты должны быть целыми числами.");

        return new LinearEquation(a, b);
    }

    public static bool SolveSystem(LinearEquation eq1, LinearEquation eq2, out double x, out double y, out string error)
    {
        int a1 = eq1.A, b1 = eq1.B;
        int a2 = eq2.A, b2 = eq2.B;

        int determinant = a1 * b2 - a2 * b1;

        if (determinant != 0)
        {
            x = 0;
            y = 0;
            error = null;
            return true;
        }
        else
        {
            x = 0;
            y = 0;
            error = "Система имеет бесконечно много решений (определитель равен нулю).";
            return false;
        }
    }
}

class Task
{
    public void test()
    {
        Console.WriteLine("Решение системы двух линейных уравнений вида Ax + By = 0");
        Console.WriteLine("Введите коэффициенты первого уравнения (A1 B1):");
        string input1 = Console.ReadLine();

        Console.WriteLine("Введите коэффициенты второго уравнения (A2 B2):");
        string input2 = Console.ReadLine();

            LinearEquation eq1 = LinearEquation.My_Parse(input1);
            LinearEquation eq2 = LinearEquation.My_Parse(input2);

            if (SolveSystem(eq1, eq2, out double x, out double y, out string error))
                Console.WriteLine($"Решение системы: x = {x}, y = {y}");
            else
                Console.WriteLine($"Ошибка: {error}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Task t = new Task();
        t.test();
    }
}