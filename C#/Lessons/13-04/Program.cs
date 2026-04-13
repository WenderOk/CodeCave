using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_04
{
    public delegate void MyDelegate();
    internal class Program
    {
        public static void Hello()
        { Console.WriteLine("Text"); }
        public static void First() => Console.WriteLine("Hello");
        public static void Second() => Console.WriteLine("Second hello");
        public static void Third() => Console.WriteLine("Some text");

        class College
        {
            string Name;
            public void PrintInfo()
            { Console.WriteLine("College info"); }

        }

        public enum OperationType{ Add, Substract, Multiply};
        public delegate T Operation<T, K>(T a, K b);

        public static int Add(int x, int y) => x + y;
        public static int Subtract(int x, int y) => x - y;
        public static int Multiply(int x, int y) => x * y;

        public static string ConcatInt(string s, int n) => $"{s} {n}";
        public static string ConcatDouble(string s, double n) => $"{s} {n}";

        public static Operation<int, int> AddOperation = Add;
        public static Operation<string, int> ConcatOperation = ConcatInt;
        public static Operation<string, double> ConcatDoubleOp = ConcatDouble;
        

        static void Main(string[] args)
        {

            Console.WriteLine(AddOperation(1, 2));
            Console.WriteLine(ConcatOperation("Hello", 10));
            Console.WriteLine(ConcatDoubleOp("Hello", 1.21));




        }
    }
}
