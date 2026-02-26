using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr2;
            arr2 = new int[5];
            int[] arr1 = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[,] arr3 = new int[2, 3] { { 2, 3, 4 }, { 5, 9, 4 } };
            for (int i = 0; i < arr1.Length; i++)
            {
                Console.WriteLine(arr1[i] + " ");
            }
            foreach (int item in arr2)
            {
                Console.WriteLine(item + " ");
            }
            Console.WriteLine("Enter a number: ");
            try
            {
                int age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(age);
            }
            catch
            {
                Console.WriteLine("You made a mistake...");
            }

        }
    }
}
