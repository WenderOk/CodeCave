using System.Runtime.InteropServices;

namespace FirstProject
{
    internal class Program
    {
        enum DaysOfWeek { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday}
        public class Pupil
        {
            public int Number;
            public string Name;
            public int Age;

            public Pupil(int numberP, string nameP, int AgeP)
            {
                Number = numberP;
                Name = nameP;
                Age = AgeP;
            }
        }

        public class Vector3
        {
            public float x; 
            public float y;
            public float z;
            public Vector3(float x, float y, float z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }

            public void print()
            {
                Console.WriteLine($"{x} {y} {z}");
            }
        }

        static void Main(string[] args)
        {
            //int[] Arr;
            //Arr = new int[5] { 12, 358, 4, 5, 6 };
            //foreach (int item in Arr)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();

            //string[] myStr;
            //myStr = new string[5];
            //string str1 = "Lesson1";
            //string str2 = str1;
            //str2 += "!";
            //Console.WriteLine(str1);
            //Console.WriteLine(str2);
            //DayOfWeek day = DayOfWeek.Monday;
            //Console.WriteLine(day + 1);

            Console.WriteLine("Enter 2 numbers");
            int a, b;
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());
            for (int i = a; i < b; i++)
            {
                if(i%2==0)
                {
                    Console.Write(i + " ");
                }
            }

        }
    }
}
