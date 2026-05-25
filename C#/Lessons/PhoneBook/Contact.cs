using System;

namespace PhoneBook
{
    public class Contact
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Group { get; set; }      // Для ComboBox (например: Семья, Работа)
        public string Gender { get; set; }     // Для RadioButton (М / Ж)

        public Contact() { }

        public Contact(string name, string phone, string group, string gender)
        {
            Name = name;
            Phone = phone;
            Group = group;
            Gender = gender;
        }

        public override string ToString()
        {
            return $"{Name} — {Phone}"; 
        }
    }
}
