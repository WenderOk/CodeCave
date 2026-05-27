using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27_05
{
    public class Person
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Password {  get; set; }

        public Person() { }

        public Person(string name, string mail, string password)
        {  Name = name; Mail = mail; Password = password; }

        public string Display { get { return $"{Name} - {Mail} - {Password}"; } }

        public override string ToString()
        {
            return $"{Name} - {Mail} - {Password}";
        }

    }
}
