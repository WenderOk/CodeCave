using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_06.Model
{
    public class Contact
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Contact() { }

        public Contact(string name, string email, string phone) 
        {
            Name = name;
            Email = email;
            Phone = phone;
        }
    }
}
