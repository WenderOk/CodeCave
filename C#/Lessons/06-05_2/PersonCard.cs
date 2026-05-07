using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _06_05_2
{
    internal class PersonCard
    {
        private string organization;
        private string filial;
        private string filialCity;
        private int id;
        private string lastName;
        private string firstName;
        private string patronymic;
        private int category;
        private string addressCity;
        private string addressStreet;

        public string Organization { get; set; }
        public string Filial { get; set; }
        public string FilialCity { get; set; }
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public int Category { get; set; }
        public string AddressCity { get; set; }
        public string AddressStreet { get; set; }

        public PersonCard() { }
        public PersonCard(string org, string fil, string filCity, string lName, string fName, string pName, int cat, string addCity, string addStr)
        {
            Organization = org;
            Filial = fil;
            FilialCity = filCity;
            LastName = lName;
            FirstName = fName;
            Patronymic = pName;
            Category = cat;
            AddressCity = addCity;
            AddressStreet = addStr;
        }
    }
}
