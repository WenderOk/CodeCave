using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace _13_05_5
{
    public partial class Form1 : Form
    {
        private int next_id = 1;
        public BindingList<Person> persons;
        private string currentFileName = "";
        public Form1()
        {
            InitializeComponent();
            persons = new BindingList<Person>()
            {
                new Person(1, "Ivanov", "Semen", "Sergeevich", "HR 789 456"),
		        new Person(2, "Moxov", "Veniamin", "Evseevich", "HR 123 587"),
		        new Person(3, "Averin", "Fedor", "Mixailovich", "HR 736 954")
            };
            SaveToXml();

            PersonsListBox.DataSource = persons;
            PersonsListBox.DisplayMember = "Display";

        }

        // метод сохранения в файл
        private void SaveToXml(string path = "persons.xml")
        {
            XmlSerializer serializer =
                new XmlSerializer(typeof(BindingList<Person>));

            using (FileStream fs =
                new FileStream(path, FileMode.Create))
            {
                serializer.Serialize(fs, persons);
            }
        }

        // метод загрузки из файла
        public void LoadFromXml()
        {
            if (!File.Exists("persons.xml"))
                return;

            XmlSerializer serializer =
                new XmlSerializer(typeof(BindingList<Person>));

            using (FileStream fs =
                new FileStream("persons.xml", FileMode.Open))
            {
                persons = (BindingList<Person>)serializer.Deserialize(fs);
            }

            PersonsListBox.DataSource = persons;
        }

        private void ExitButton_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }
    }
}
