using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_04
{
    interface ISquare
    { double GetSquare(); }

    interface IPerimetr
    { double GetPerimetr(); }

    abstract class Shape
    { public abstract string Name { get; } }

    class Square : Shape, ISquare, IPerimetr
    {
        public double Side;

        public Square(double side)
        { Side = side; }

        public override string Name => "Square";

        public double GetSquare()
        { return Side * Side; }

        public double GetPerimetr()
        { return 4 * Side; }
    }

    class Circle : Shape, ISquare, IPerimetr
    {
        public double Radius;

        public Circle(double radius)
        { Radius = radius; }

        public override string Name => "Circle";

        public double GetSquare()
        { return Math.PI * Radius * Radius; }

        public double GetPerimetr()
        { return 2 * Math.PI * Radius; }
    }

    class Triangle : Shape, ISquare, IPerimetr
    {
        public double A;
        public double B;
        public double C;

        public Triangle(double a, double b, double c)
        {
            if (a + b <= c || a + c <= b || b + c <= a)
            { Console.WriteLine("Triangle with this sides cannot exist!"); } // все равно не выводится при создании несуществующего треугольника

            A = a;
            B = b;
            C = c;
        }

        public override string Name => "Trianlge";

        public double GetSquare()
        {
            double p = (A + B + C) / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }

        public double GetPerimetr()
        { return A + B + C; }
    }

    class Task
    {
        public void run()
        {
            Square sq = new Square(12);
            Circle cir = new Circle(7);
            Triangle tr1 = new Triangle(12, 8, 7);

            Console.WriteLine($"{sq.Name}: side = {sq.Side}, area = {sq.GetSquare()}, perimetr = {sq.GetPerimetr()}\n");
            Console.WriteLine($"{cir.Name}: radius = {cir.Radius}, area = {cir.GetSquare()}, perimetr = {cir.GetPerimetr()}\n");
            Console.WriteLine($"{tr1.Name}: sides = {tr1.A}, {tr1.B}, {tr1.C}, area = {tr1.GetSquare()}, perimetr = {tr1.GetPerimetr()}");
            Console.ReadLine();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Task t = new Task();
            t.run();
        }
    }
}
