using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;

namespace _01_06
{
    public class ContactManager
    {
        private string path = "contacts.xml";
        private ObservableCollection<Contact> contacts =
            new ObservableCollection<Contact>();
        public ObservableCollection<Contact> Contacts{ get; set; }

        public ContactManager(ObservableCollection<Contact> contacts)
        { Contacts = contacts; }
        public ContactManager()
        { Contacts = new ObservableCollection<Contact>(); }


        //метод проверки, что поля не пустые
        public bool FieldsIsNullOrEmpty(Contact contact)
        {
            return (!String.IsNullOrEmpty(contact.Name) &&
                           !String.IsNullOrEmpty(contact.Email) &&
                           !String.IsNullOrEmpty(contact.PhoneNumber));

        }

        public bool AddContact(Contact contact)
        {
            if(FieldsIsNullOrEmpty(contact))
            {
                Contacts.Add(contact);
                return true;
            }
            return false; 
        }

        public bool EditContact(int index, Contact contact)
        {
            if(index >= 0 && index < Contacts.Count)
            {
                if(FieldsIsNullOrEmpty(contact))
                {
                    Contacts[index] = contact;
                    return true;
                }
            }
            return false;
        }

        public void RemoveContact(Contact contact)
        {  contacts.Remove(contact); }

        public void SaveToFile(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Contact>));
            using (FileStream fs = new FileStream(path, FileMode.Create))
            { serializer.Serialize(fs, Contacts); }
        }

        public void LoadFromFile(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Contact>));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            { Contacts = (ObservableCollection<Contact>)serializer.Deserialize(fs); }
        }

    }
}
