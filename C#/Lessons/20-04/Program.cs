using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace _20_04
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronim { get; set; }
        public Passport Passoprt { get; set; }
        public string Address { get; set; }
        public Person() { }
        public Person(int id, string firstName, string lastName, string patronim, Passport passoprt, string address)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Patronim = patronim;
            Passoprt = passoprt;
            Address = address;
        }

        public override string ToString()
        {
            return $"ID {Id}\n" +
                    $"Name {FirstName}\n" +
                    $"lastname {LastName}\n" +
                    $"Patronim {Patronim}\n" +
                    $"Pass {Passoprt.Seria} - {Passoprt.Number}\n" +
                    $"Address {Address}\n";
        }
    }

    public class Passport
    {
        public string Seria { get; set; }
        public int Number { get; set; }
        public Passport(string seria, int number)
        {
            Seria = seria;
            Number = number;
        }
    }

    public class Group
    {
        public string GroupName { get; set; }
        public List<Person> People { get; set; }

        public Group() 
        { 
            GroupName = string.Empty;
            People = new List<Person>();
        }

        public Group(string groupName)
        {
            GroupName = groupName;
            People = new List<Person>();
            People.Add(new Person(1, "asd", "asd", "asd",
                new Passport("asd", 123456), "asd"));
            People.Add(new Person(1, "zxc", "zxc", "zxc",
                new Passport("zxc", 654321), "zxc"));
            People.Add(new Person(1, "asd", "asd", "asd",
                new Passport("asd", 45656), "asd"));
            People.Add(new Person(1, "asd", "asd", "asd",
                new Passport("asd", 234524), "asd"));
            People.Add(new Person(1, "qwe", "qwe", "qwe",
                new Passport("qwe", 657574), "qwe"));
        }
    }

    internal class Program
    {
        public class SaveToText
        {
            string path = "group_text.txt";
            public Group group {  get; set; }
            
            public SaveToText()
            {
                group = new Group("RPO");
                using(StreamWriter sw = new StreamWriter(path, false))
                {
                    sw.WriteLine(group.GroupName);
                    foreach (Person p in group.People)
                    {
                        string item = $"{p.Id}|{p.FirstName}|{p.LastName}|{p.Patronim}|{p.Passoprt.Seria}|{p.Passoprt.Number}|{p.Address}";
                        sw.WriteLine(item);
                    }
                }
            }
        }
        public class ReadFromText
        {
            string path = "group_text.txt";
            public Group group { get; set; }
            public ReadFromText()
            {
                group = new Group();
                using (StreamReader rw = new StreamReader(path, false))
                {
                    group.GroupName =  rw.ReadLine();
                    string line;
                    while ((line = rw.ReadLine()) != null)
                    {
                        string[] items = line.Split('|');
                        if (items.Length != 7)
                            continue;
                        int id, passport;
                        int.TryParse(items[0], out id);
                        int.TryParse (items[5], out passport);
                        Person p = new Person(id, items[1], items[2], items[3], new Passport(items[4], passport), items[5]);
                        group.People.Add(p);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Group g = new Group("RPO");
            Console.WriteLine(g.GroupName);
            foreach (Person p in g.People)
                Console.WriteLine(p);

            SaveToText saveToText = new SaveToText();
            ReadFromText readFromText = new ReadFromText();

        }
    }
}
