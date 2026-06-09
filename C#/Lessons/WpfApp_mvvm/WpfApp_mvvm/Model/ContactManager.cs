using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace WpfApp_mvvm.Model
{
    public class ContactManager
    {
        private string path = "contacts.xml";
        private ObservableCollection<Contact> contacts = 
            new ObservableCollection<Contact>();
        public ObservableCollection<Contact> Contacts => contacts;
        public ContactManager() { }

        // Метод для проверки полей
        public bool FieldsAreValid(Contact contact)
        {
            // Проверка на пустое поле имени
            if (string.IsNullOrEmpty(contact.Name))
            {
                MessageBox.Show("Имя не должно быть пустым", "Заполнены не все поля");
                return false;
            }
            // Проверка на пустое поле имени
            if (string.IsNullOrEmpty(contact.PhoneNumber))
            {
                MessageBox.Show("Номер телефона не должен быть пустым", 
                                "Заполнены не все поля");
                return false;
            }
            // Проверка на пустое поле имени
            if (string.IsNullOrEmpty(contact.Email))
            {
                MessageBox.Show("Почта не должно быть пустым", "Заполнены не все поля");
                return false;
            }
            // Проверка номера телефона на формат +7 999 999-99-99
            if (!System.Text.RegularExpressions.Regex.IsMatch(contact.PhoneNumber, @"^\+7 \d{3} \d{3}-\d{2}-\d{2}$"))
            {
                MessageBox.Show("Номер телефона должен быть в формате +7 999 999-99-99", "Некоректные данные");
                return false;
            }
            // Проверка почты на формат mail@mail.ru
            if (!System.Text.RegularExpressions.Regex.IsMatch(contact.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Почта должна быть в формате mail@mail.ru", "Некоректные данные");
                return false;
            }
            return true;
        }

        // Метод для добавления элементов
        public bool AddContact(Contact contact)
        {
            if (FieldsAreValid(contact))
            {
                contacts.Add(contact);
                return true;
            }
            return false;
        }


        //метод для сохранения списка в файл
        public void SaveContacts()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Contact>));
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                serializer.Serialize(fs, contacts);
            }
        }

        // метод загрузки из файла
        public void LoadContacts()
        {
            if (!File.Exists(path))
                return;

            XmlSerializer serializer =
                new XmlSerializer(typeof(ObservableCollection<Contact>));

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                contacts = (ObservableCollection<Contact>)serializer.Deserialize(fs);
            }
        }
        //метод для редактирования элементов
        public bool EditContact(int index, Contact contact)
        {
            if (FieldsAreValid(contact))
            {
                contacts[index] = contact;
                return true;
            }
            return false;

        }
        //метод для удаления элемента по индексу
        public bool RemoveByIndex(int index)
        {
            if (index >= 0 && index < contacts.Count)
            {
                contacts.RemoveAt(index);
                return true;
            }
            else
            {
                MessageBox.Show("index вне диапазона");
                return false;
            }
        }





    }
}
