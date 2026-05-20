using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
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
        public void LoadFromXml(string path = "persons.xml")
        {
            if (!File.Exists(path))
                return;

            XmlSerializer serializer =
                new XmlSerializer(typeof(BindingList<Person>));

            using (FileStream fs =
                new FileStream(path, FileMode.Open))
            {
                persons = (BindingList<Person>)serializer.Deserialize(fs);
            }

            PersonsListBox.DataSource = null;
            PersonsListBox.DataSource = persons;

            PersonsListBox.DisplayMember = "Display";
            next_id = persons.Max(p => p.Id);
            next_id++;
        }

        private void ExitButton_MouseClick(object sender, MouseEventArgs e)
        {
            var result = MessageBox.Show(
            "Сохранить изменения?",
            "Выход",
            MessageBoxButtons.YesNoCancel,
            MessageBoxIcon.Question);

            if (result == DialogResult.Cancel)
                return;

            if (result == DialogResult.Yes)
            {
                closeToolStripMenuItem_Click(sender, e);
            }
            this.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "XML files (*.xml)|*.xml";

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                currentFileName = dialog.FileName;
                LoadFromXml(currentFileName);
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentFileName))
            {
                SaveFileDialog dialog = new SaveFileDialog();

                dialog.Filter = "XML files (*.xml)|*.xml";

                if(dialog.ShowDialog() == DialogResult.OK)
                {
                    currentFileName = dialog.FileName;
                }
                else return;
            }
            
            SaveToXml(currentFileName);
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            //form2.ShowDialog();
            if (form2.ShowDialog() == DialogResult.OK)
            {
                Person p = form2.NewPerson;

                p.Id = next_id++;
                persons.Add(p);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(PersonsListBox.SelectedItems == null)
            {
                MessageBox.Show("Выберете человека!");
                return;
            }

            Person p = (Person)PersonsListBox.SelectedItem;

            Form2 form = new Form2(p);

            if(form.ShowDialog() == DialogResult.OK)
            {
                PersonsListBox.DataSource = null;
                PersonsListBox.DataSource = persons;
                PersonsListBox.DisplayMember = "Display";
            }

        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(PersonsListBox.SelectedItem == null)
            {
                MessageBox.Show("Выберете человека!");
                return;
            }
            var result = MessageBox.Show(
            "Уверены что хотите удалить?",
            "Выход",
            MessageBoxButtons.YesNoCancel,
            MessageBoxIcon.Question);

            Person p = (Person)PersonsListBox.SelectedItem;
            persons.Remove(p);
        }

        private void sortByNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Person> sortedList = persons.OrderBy(p => p.LastName).ThenBy(p => p.FirstName).ToList();

            persons.Clear();

            foreach(Person p in sortedList)
                persons.Add(p);
        }
    }
}
