using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _13_05_5
{
    public class Person
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronomic { get; set; }
        public string CertificateNumber { get; set; }

        [XmlIgnore]
        public string Display
        {
            get
            {
                return $"{Id} {LastName} {FirstName} - {CertificateNumber}";
            }
        }
        public Person()
        { }
        public Person(int idP, string last_nameP, string first_nameP, string patP, string cert_numP)
        {
            Id = idP;
            LastName = last_nameP;
            FirstName = first_nameP;
            Patronomic = patP;
            CertificateNumber = cert_numP;
        }
    }
}
