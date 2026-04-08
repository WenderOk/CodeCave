using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleApp1
{
    internal class Program
    {
        public class Point
        {
            public int X;
            public int Y;

            public Point(int x, int y) { X = x; Y = y; }

            public override bool Equals(object obj)
            { return this.ToString() == obj.ToString(); }

            public override int GetHashCode()
            { return this.ToString().GetHashCode(); }

            public static Point operator ++(Point p)
            {
                p.X++; p.Y++;
                return p;
            }

            public static Point operator --(Point p)
            {
                p.X--; p.Y--;
                return p;
            }

            public static Point operator +(Point p1, Point p2)
            { return new Point(p1.X + p2.X, p1.Y + p2.Y); }

            public static Point operator -(Point p1, Point p2)
            { return new Point(p1.X - p2.X, p1.Y - p2.Y); }

            public static bool operator ==(Point p1, Point p2)
            { return p1.Equals(p2); }

            public static bool operator !=(Point p1, Point p2)
            { return !p1.Equals(p2); }

            public static bool operator >(Point p1, Point p2)
            { return (p1.X > p2.X) && (p1.Y > p2.Y); }

            public static bool operator <(Point p1, Point p2)
            { return (p1.X < p2.X) && (p1.Y < p2.Y); }

            public override string ToString()
            {
                return $"{X}, {Y}";
            }
        }

        public  class PointsArray : IEnumerator
        {
            public Point[] array;
            public PointsArray(Point[] array) { this.array = array; }
            int position = -1;
            public int Length {  get { return array.Length; } }
            public bool MoveNext()
            {
                position++;
                return position < array.Length;
            }

            public void Reset()
            {
                position = -1;
            }

            object IEnumerator.Current
            { get { return Current; } }

            public Point Current
            { get {
                    try
                    {
                        return array[position]; 
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                        throw new InvalidOperationException(ex.Message);
                    }
                } 
            }

        }

      

        static void Main(string[] args)
        {
            Point p1 = new Point(2, 5);
            Point p2 = new Point(3, 10);
            Point p3 = new Point(3, 10);
            Console.WriteLine($"{p2} == {p3} {p2 == p3}");
            p3++;
            p2--;
            Console.WriteLine($"{p2} == {p3} {p2 == p3}");
            Console.WriteLine($"{p2} + {p3} {p2 + p3}");
            Console.WriteLine($"{p2} - {p2} {p2 - p3}");
            Console.WriteLine($"{p2} > {p2} {p2 > p3}");
            Console.ReadKey();

            Point[] arr = { p1, p2, p3 };
            PointsArray array = new PointsArray(arr);
            foreach (Point p in array)
            { Console.WriteLine(p); }

        }
    }
}
