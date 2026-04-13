using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_delegate_1
{
    public enum OperationType {Add, Minus, Multiply }

    public delegate void MyDelegate(); 
    public delegate void MyDelegate2(string message);
    public delegate int Operation(int a, int b);
    public delegate T Operation2<T, K>(T a, K b);
    internal class Program
    {
        public static void Hello()
        { Console.WriteLine("Text"); }
        public static void First() => Console.WriteLine("Important information");
        public static void Second() => Console.WriteLine("Dop. information");
        public static void Third() => Console.WriteLine("бла-бла-бла");
        public static void ShowMessage(string message)
        { 
            Console.WriteLine(message); 
        }
        public class College
        { 
            public string Name { get; set; }
            public College(string nameP)
            {
                Name = nameP;
            }
            public void PrintInfo()
            {
                Console.WriteLine($"Колледж {Name} предлагает " +
                    $"ознакомиться с информацией");
            }
        }
        public static void ShowMessageRed(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public static int Add(int x, int y) { return x + y; }
        public static int Minus(int x, int y) => x - y;
        public static int Multiply(int x, int y) => x * y;
        public static Operation SelectOperation(OperationType opType)
        { 
            switch (opType) 
            {
                case OperationType.Add: return Add;
                case OperationType.Multiply: return Multiply;   
                default: return Minus;
            }
        }
        public static void Calculate(int x, int y, Operation op)
        {
            int result=op(x, y); // вызываем делегат
            Console.WriteLine(result);
        }

        public static double Mult2(double x, int y) => y*x;
        public static int Mult3(int x, int y) => x*y;


        public static string Print(string str1,string str2)
            => str1+ str2;
        public static string Print2(string str1, int n)
        { 
            string s=string.Empty;
            for (int i = 0; i < n; i++)
            {
                s+= str1;
            }
            return s;
        }
        static void Main(string[] args)
        {
            MyDelegate md;
            md = Hello; //сохраняем ссылку на метод
            //md();
            md += First;
            md += Second;
            md += Third;
            College college = new College("Top Academy");
            // говорим, что экземпляр делегата md
            // сообщается с методами First, Second, Hello ...
            md += college.PrintInfo;

            md.Invoke();
            Console.WriteLine();
            md-=Hello;
            md.Invoke();

            Console.WriteLine();
            MyDelegate2 mes2;
            mes2 = ShowMessage;
            //делегат с несколькими методами - multicast delegate
            mes2 += ShowMessageRed;
            mes2.Invoke("My message delegate");
            Console.WriteLine();
            mes2 -= ShowMessage;
            mes2("jfjsdlkfjsdfj");                            //I способ вызова
            mes2.Invoke("My message delegate после отписки");  // II способ вызова

            // отпишемся от всех методов
            mes2 -= ShowMessageRed;
            //mes2("kjskd_null");  //error
            // при вызове нужно проверять на null
            if(mes2 != null)                        // I способ проверки на null
            {
                mes2.Invoke("mes2 == null");
            }
            else Console.WriteLine("mes2 == null");
             mes2?.Invoke("mes2 == null");        // II способ проверки на null

            Console.WriteLine();
            Operation operation = Add;
            int result = operation(45, 5);
            Console.WriteLine(result);
            operation += Minus;
            result=operation(50,5);
            Console.WriteLine();
            Console.WriteLine(result);

            // делегат как аргумент метода
            Console.WriteLine();
            Calculate(2, 8, Add);
            Calculate(10, 8, Multiply);
            Calculate(100, 60, Minus);
            // использование лямбды
            Calculate(5,10,(x,y) => 100*x-y);

            Console.WriteLine("\n    обобщенный делегат");
            Operation2<double, int> op2 = Mult2;
            Console.WriteLine(op2.Invoke(45.5,10));
            Operation2<int,int> op3 = Mult3;
            Console.WriteLine(op3.Invoke(5, 10));
            Operation2<string, string> op4 = Print;
            Console.WriteLine(op4.Invoke("kkk", "aaa"));
            Operation2<string,int> op5 = Print2;
            Console.WriteLine(op5.Invoke("Sun", 5));

            //Встроенные делегаты
            Action<string> print = ShowMessage;
            print("Добрый день");

            Action<int, int> printSum = (int num1, int num2) =>
            { Console.WriteLine(num1 + num2); };
            printSum(400, 100);

            Func<College, string> n = (c) => c.Name;
            Console.WriteLine(n(college));

            Func<int, int, int> sum = (x, y) => x + y;
            Console.WriteLine(sum(10,20));
            Console.WriteLine(sum.Invoke(100, 200));

            Func<int, int, int> sum_lambda = Add;
            Console.WriteLine(sum_lambda(155, 45));

            Func<int, int, string> concatInString = (int x, int y) =>
            $"{x}_{y}";

            Predicate<int> IsLargerZero = (int x) => x > 0;
            print(IsLargerZero(-5).ToString());
            print(IsLargerZero(9).ToString());

            Comparison<int> cmp=(int x, int y) => x > y ? -1 : 1;
            Comparison<int> cmp2 = (int x, int y) =>
            {
                if (x > y) return -1;
                if (x < y) return 1;
                else return 0;
            };
            int a = 4, b = 5;
            print($"сравнение чисел: {a}{b} - {cmp2(a, b)}");
            print($"сравнение чисел: {b}{a} - {cmp2(b, a)}");
            a = 5;
            print($"сравнение чисел: {a}{b} - {cmp2(a, b)}");




            Console.ReadKey();
        }
    }
}
