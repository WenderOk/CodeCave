using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _03_06.Model
{
    public class ContactManager
    {
        private string filePath = "Contacts.xml";
        private ObservableCollection<Contact> contacts
            = new ObservableCollection<Contact>();
        public ObservableCollection<Contact> Contacts => contacts;
        public ContactManager() { }

        public bool FieldsAreValid(Contact contact)
        {
            return (!String.IsNullOrEmpty(contact.Name) &&
                           !String.IsNullOrEmpty(contact.Email) &&
                           !String.IsNullOrEmpty(contact.Phone)) &&
                           Regex.IsMatch(contact.Email, @"^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$") &&
                           Regex.IsMatch(contact.Phone, @"^\+?[1-9]\d{1,14}$");
        }

        public bool AddContact(Contact contact)
        {
            if (FieldsAreValid(contact))
            {
                Contacts.Add(contact);
                return true;
            }
            return false;
        }

        public bool EditContact(int index, Contact contact)
        {
            if (index >= 0 && index < Contacts.Count)
            {
                if (FieldsAreValid(contact))
                {
                    Contacts[index] = contact;
                    return true;
                }
            }
            return false;
        }

        public void RemoveContact(Contact contact)
        { Contacts.Remove(contact); }

        public void SaveContacts(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Contact>));
            using (FileStream fs = new FileStream(path, FileMode.Create))
            { serializer.Serialize(fs, Contacts); }
        }

        public void LoadContacts(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Contact>));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            { contacts = (ObservableCollection<Contact>)serializer.Deserialize(fs); }
        }

    }
}
