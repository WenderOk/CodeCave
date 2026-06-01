using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_06
{
    public class Contact
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Contact()
        {

        }
        public Contact(string nameP, string phoneP, string emailP)
        {
            Name = nameP;
            PhoneNumber = phoneP;
            Email = emailP;
        }
    }
}
