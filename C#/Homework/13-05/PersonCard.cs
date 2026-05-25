using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace _06_05_2
{
    public class PersonCard
    {
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
        public PersonCard(string org, string fil, string filCity, int id, string lName, string fName, string pName, int cat, string addCity, string addStr)
        {
            Organization = org;
            Filial = fil;
            FilialCity = filCity;
            Id = id;
            LastName = lName;
            FirstName = fName;
            Patronymic = pName;
            Category = cat;
            AddressCity = addCity;
            AddressStreet = addStr;
        }
        public override string ToString()
        {
            return $"{Organization} - {Filial} - {FilialCity} " +
                    $"{Id} - {LastName} {FirstName} {Patronymic} " +
                    $"категория {Category} - Прописка {AddressCity}, {AddressStreet}";
        }
        public string Display
        {
            get
            {
                return $"{Organization} - {Filial} - {FilialCity} " +
                    $"{Id} - {LastName} {FirstName} {Patronymic} " +
                    $"категория {Category} - Прописка {AddressCity}, {AddressStreet}";
            }
        }

        public static void SaveToXml(BindingList<PersonCard> list, string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BindingList<PersonCard>));
            using (TextWriter writer = new StreamWriter(fileName))
            {
                serializer.Serialize(writer, list);
            }
        }

        public static BindingList<PersonCard> LoadFromXml(string fileName)
        {
            if (!File.Exists(fileName))
                return new BindingList<PersonCard>();

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(BindingList<PersonCard>));
                using (TextReader reader = new StreamReader(fileName))
                {
                    return (BindingList<PersonCard>)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}\nБудет создан пустой список.");
                return new BindingList<PersonCard>();
            }
        }
    }
}
