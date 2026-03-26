using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30_03
{
    public enum mainSubjects { русский_язык, матеметика, физика };
    public enum optionalSubjects { программирование, английский_язык, литература };

    namespace TOP
    {
        public class College
        {
            public string CollegeName = "TOP";
            public List<mainSubjects> MainSubjects;

            public College(List<mainSubjects> mainSubjects)
            {
                MainSubjects = mainSubjects;
            }

            public override string ToString()
            {
                string subjects = string.Join(", ", MainSubjects);
                return $"Название колледжа: {CollegeName}\nОбязательные предметы: {subjects}\n";
            }
        }

        public class Filial : College
        {
            public string FilialName = "Москва";
            public List<optionalSubjects> OptionalSubjects;

            public Filial(List<mainSubjects> mainSubjects, string filialName, List<optionalSubjects> optionalSubjects) : base(mainSubjects)
            {
                OptionalSubjects = optionalSubjects;
                FilialName = filialName;
            }

            public override string ToString()
            {
                string subjects = string.Join(", ", OptionalSubjects);
                return base.ToString() + $"Название филиала: {FilialName}\nДополнтиельные предметы: {subjects}\n";
            }
        }
    }

    namespace SPBGU
    {
        public class College
        {
            public string CollegeName = "СПБГУ";
            public List<mainSubjects> MainSubjects;

            public College(List<mainSubjects> mainSubjects)
            {
                MainSubjects = mainSubjects;
            }

            public override string ToString()
            {
                string subjects = string.Join(", ", MainSubjects);
                return $"Название колледжа: {CollegeName}\nОбязательные предметы: {subjects}\n";
            }
        }

        public class Filial : College
        {
            public string FilialName = "Выборг";
            public List<optionalSubjects> OptionalSubjects;

            public Filial(List<mainSubjects> mainSubjects, string filialName, List<optionalSubjects> optionalSubjects) : base(mainSubjects)
            {
                OptionalSubjects = optionalSubjects;
                FilialName = filialName;
            }

            public override string ToString()
            {
                string subjects = string.Join(", ", OptionalSubjects);
                return base.ToString() + $"Название филиала: {FilialName}\nДополнтиельные предметы: {subjects}\n";
            }
        }
    }

    public class Task
    {
        public void Test()
        {
            var msTOP1 = new List<mainSubjects> { mainSubjects.русский_язык, mainSubjects.матеметика };
            var osTOP1 = new List<optionalSubjects> { optionalSubjects.английский_язык, optionalSubjects.литература };
            var msTOP2 = new List<mainSubjects> { mainSubjects.физика, mainSubjects.матеметика };
            var osTOP2 = new List<optionalSubjects> { optionalSubjects.программирование, optionalSubjects.английский_язык };
            TOP.Filial filialTOP1 = new TOP.Filial(msTOP1,"Москва", osTOP1);
            TOP.Filial filialTOP2 = new TOP.Filial(msTOP1,"Питер", osTOP1);

            Console.WriteLine(filialTOP1);
            Console.WriteLine(filialTOP2);

            var msPTU1 = new List<mainSubjects> { mainSubjects.физика, mainSubjects.матеметика };
            var osPTU1 = new List<optionalSubjects> { optionalSubjects.английский_язык, optionalSubjects.программирование };
            var msPTU2 = new List<mainSubjects> { mainSubjects.русский_язык, mainSubjects.матеметика };
            var osPTU2 = new List<optionalSubjects> { optionalSubjects.английский_язык, optionalSubjects.литература };
            SPBGU.Filial filialPTU1 = new SPBGU.Filial(msPTU1,"Новгород", osPTU1);
            SPBGU.Filial filialPTU2 = new SPBGU.Filial(msPTU2,"Самара", osPTU2);

            Console.WriteLine(filialPTU1);
            Console.WriteLine(filialPTU2);

            Console.ReadKey();
        }
    }


    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // У меня русский не работал просто

            Task t = new Task();
            t.Test();

        }
    }
}


