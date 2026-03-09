using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETApp
{
    internal class Program
    {
        public class Task1
        {
            public string InsertStringBeforeSubstr(string text, string string_before, string string_to_insert)
            {
                int index = text.IndexOf(string_before);
                string result="";
                if (index != -1)
                    result = text.Insert(index, string_to_insert + " ");
                else
                    return "";
                return result;
            }
            
        }
        public class Task2
        {
            public string InsertStringAfterSubstr(string text, string string_after, string string_to_insert)
            {
                int index = text.IndexOf(string_after);

                if (index != -1)
                {
                    int insert_pos = index + string_after.Length;
                    string result = text.Insert(insert_pos, ", " + string_to_insert);
                    return result;
                }
                else
                    return "";
            }
            
        }
        public class Task3
        {
            public int[] CompressArr(int[] array)
            {
                int nonZeroIndex = 0;

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] != 0)
                    {
                        array[nonZeroIndex] = array[i];
                        nonZeroIndex++;
                    }
                }

                for (int i = nonZeroIndex; i < array.Length; i++)
                    array[i] = -1;
                return array;
            }
            
        }

        static void Main(string[] args)
        {
            Task1 t1 = new Task1();
            Task2 t2 = new Task2();
            Task3 t3 = new Task3();

            Console.WriteLine("Task 1:\n" + t1.InsertStringBeforeSubstr("Вчера мама купила торт", "торт", "большой"));
            Console.WriteLine("Task 2:\n" + t2.InsertStringAfterSubstr("dog, cat, elephant, tiger, bear, zebra", "elephant", "rabbit"));
            int[] array = { 54, 0, 0, 2, 0, 43, 0, 0, 65 };
            int[] res = t3.CompressArr(array);
            Console.WriteLine("Task 3:\n" + string.Join(", ", array));

        }
    }
}


