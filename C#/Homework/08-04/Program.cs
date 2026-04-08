using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace _08_04
{
    interface ISquare
    { double GetSquare(); }

    interface IPerimetr
    { double GetPerimetr(); }

    public abstract class Shape
    { public abstract string Name { get; } }

    public class TriangleExceprion : ApplicationException
    {
        public TriangleExceprion() : base("Triangle with this sides cannot exist!") { }
    }

    public interface ILogger
    {
        void Log(string message);
        void ErrorLog(string message);
    }

    public class ConsoleLogger : ILogger
    {
        public void ErrorLog(string message)
        {
            Console.WriteLine($"{DateTime.Now} [ERROR]: {message}");
        }

        public void Log(string message)
        {
            Console.WriteLine($"{DateTime.Now} [INFO]: {message}");
        }
    }

    public class FileLogger : ILogger
    {
        private readonly string path = "Log.txt";
        public void ErrorLog(string message)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine($"{DateTime.Now} [ERROR]: {message}");
            }
        }

        public void Log(string message)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine($"{DateTime.Now} [INFO]: {message}");
            }
        }
    }

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

        public override string ToString()
        {
            return $"{Side} P={GetPerimetr()} S={GetSquare()}";
        }
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

        public override string ToString()
        {
            return $"{Radius} P={GetPerimetr()} S={GetSquare()}";
        }
    }

    class Triangle : Shape, ISquare, IPerimetr
    {
        public double A;
        public double B;
        public double C;

        public Triangle(double a, double b, double c)
        {
            if (a + b <= c || a + c <= b || b + c <= a)
                throw new TriangleExceprion();
            

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

        public override string ToString()
        {
            return $"{A} {B} {C} P={GetPerimetr()} S={GetSquare()}";
        }
    }

    public class ShapeManager
    {
        private readonly ILogger logger;

        public ShapeManager(ILogger logger)
        { this.logger = logger; }

        public void AddShape(List<Shape> shapes, Shape shape)
        {
            try
            {
                shapes.Add(shape);
                logger.Log("Figure succefully added");

            }
            catch (TriangleExceprion ex)
            {
                logger.ErrorLog(ex.Message);
            }
        }       
        public void AddShape2(List<Shape> shapes, Func<Shape> creator)
        {
            try
            {
                Shape shape = creator();
                shapes.Add(shape);
                logger.Log("Figure succefully added");

            }
            catch (TriangleExceprion ex)
            {
                logger.ErrorLog(ex.Message);
            }
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new FileLogger();
            ShapeManager mgr1 = new ShapeManager(logger);

            List<Shape> shapes = new List<Shape>
            {
                new Square(5),
                new Triangle(5, 5, 4)
            };

            mgr1.AddShape2(shapes, () => new Circle(5));
            mgr1.AddShape2(shapes, () => new Square(10));
            mgr1.AddShape2(shapes, () => new Triangle(2,2,10));

            foreach (Shape item in shapes)
            {
                Console.WriteLine(item);
            }
        }
    }
}
