using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW_15_06.Model
{
    public class Classification
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public Classification() { }
        public Classification(int id, string className)
        {
            Id = id;
            ClassName = className;
        }
    }
}
