using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Xml.Serialization;

namespace _27_05
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Person> persons;
        public MainWindow()
        {
            InitializeComponent();
            persons = new ObservableCollection<Person>();
            LoadFromXML("persons.xml");
        }

        private void button_registration_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_name.Text.Length > 0
                && text_password.ToString().Length > 0
                && textBox_mail.Text.Length > 0)
            {

                string email = textBox_mail.Text;
                bool valid = Regex.IsMatch(email,
                    @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$");
                //@"^[^@\s]+@[^@\s]+\.[^@\s]+$");  //либо так

                if (valid)
                {
                    textBox_information.Text = "Вы зарегистрированы";
                    Person p = new Person();
                    p.Name = textBox_name.Text;
                    p.Password = text_password.Password;
                    p.Mail = email;
                    persons.Add(p);
                }
                else MessageBox.Show("Неверная почта");
            }
            else MessageBox.Show("не все поля заполнены");
        }

        private void button_clear_Click(object sender, RoutedEventArgs e)
        {
            textBox_information.Clear();
            textBox_mail.Clear();
            textBox_name.Clear();
            text_password.Clear();
        }

        private void button_view_all_Click(object sender, RoutedEventArgs e)
        {
            WindowView win = new WindowView(persons);
            win.Show();
        }

        private void button_exit_Click(object sender, RoutedEventArgs e)
        {
            SaveXML("persons.xml");
            Close();
        }

        private void SaveXML(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Person>));
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                serializer.Serialize(fs, persons);
            }
        }
        private void LoadFromXML(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Person>));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                persons = (ObservableCollection<Person>)serializer.Deserialize(fs);
            }

        }
    }
}
