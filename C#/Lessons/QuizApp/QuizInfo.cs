using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp
{
    internal class QuizInfo
    {
        public string Name { get; set; }
        public string FilePath { get; set; }
        public QuizInfo() { }
        public QuizInfo(string name, string filePath)
        { Name = name; FilePath = filePath; }
    }
}
