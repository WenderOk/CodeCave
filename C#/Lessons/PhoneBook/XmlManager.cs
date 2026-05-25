using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace PhoneBook
{
    public static class XmlManager
    {
        private static readonly string FilePath = "contacts.xml";

        public static void SaveContacts(List<Contact> contacts)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Contact>));
            using (StreamWriter writer = new StreamWriter(FilePath))
            {
                serializer.Serialize(writer, contacts);
            }
        }

        public static List<Contact> LoadContacts()
        {
            if (!File.Exists(FilePath))
                return new List<Contact>(); // Если файла нет, возвращаем пустой список

            XmlSerializer serializer = new XmlSerializer(typeof(List<Contact>));
            using (StreamReader reader = new StreamReader(FilePath))
            {
                return (List<Contact>)serializer.Deserialize(reader);
           }
        }
    }
}
