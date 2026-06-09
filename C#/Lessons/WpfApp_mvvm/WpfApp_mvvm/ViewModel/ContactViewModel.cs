using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp_mvvm.Model;

namespace WpfApp_mvvm.ViewModel
{
    public class ContactViewModel
    {
        // Поле для работы с менеджером контактов
        private ContactManager contactManager = new ContactManager();
        // Конструктор класса
        public ContactViewModel()
        {
            contactManager.LoadContacts();
        }
        // СВОЙСТВО для DataGrid, предоставляющие доступ к списку контактов
        public ObservableCollection<Contact> Contacts { get { return contactManager.Contacts; } }

        //свойства для хранения данных, введенных пользователем в текстовые поля
        public string TextBoxName { get; set; }
        public string TextBoxEmail { get; set; }
        public string TextBoxPhoneNumber { get; set; }

        //метод для устанoвки значаний в TextBox
        public void SetTextBox(string name, string email, 
                                string phone)
        {
            TextBoxName = name;
            TextBoxEmail = email;
            TextBoxPhoneNumber = phone;
        }
        //метод для открытия окна
        private void ShowAddContactWindow()
        {
            AddWindow addWindow = new AddWindow(this);
            SetTextBox("default", "default@mail.ru", "+7 999 999-99-99");
            addWindow.ShowDialog();
        }

        //поле для введения команды открытия окна дбавления контактов
        private RelayCommand openAddContactCommand;
        //свойство для кнопки button, предоставляющее доступ к команде открытия окна
        public RelayCommand OpenAddContactCommand
        {
            get 
            {
                return openAddContactCommand ?? (
                    new RelayCommand(obj =>
                    {
                        ShowAddContactWindow();
                    })
                    );
            }
        }

        //поле для хранения команды добавления нового контакта
        private RelayCommand addContactCommand;
        //свойство, предосталяющее доступ к этой команде
        public RelayCommand AddContactCommand
        {
            get 
            {
                return addContactCommand ?? 
                (
                    new RelayCommand
                    (obj =>
                    {
                        Window window = obj as Window;
                        if (contactManager.AddContact(new Contact(TextBoxName,
                                                                 TextBoxEmail,
                                                                 TextBoxPhoneNumber)))
                        {
                            window.Close();
                        }
                    }
                    )
                );
            }
        }
        // 1. Метод для сохранения контактов
        public void SaveContacts()
        {
            contactManager.SaveContacts();
        }

        //свойство для хранения выбранного индекса
        public int SelectedIndex { get; set; }

        //метод для открытия окна редактирования контактов
        private void ShowEditContactWindow()
        {
            EditWindow editWindow = new EditWindow(this);
            if (SelectedIndex > -1)
            {
                Contact contactChange = contactManager.Contacts[SelectedIndex];
                SetTextBox(contactChange.Name, contactChange.Email, contactChange.PhoneNumber);
                editWindow.ShowDialog();
            }
        }
        //поле для хранения команды окна для редактирования
        private RelayCommand openEditContactCommand;
        //свойство для кнопки, которая открывает окно редактирования
        public RelayCommand OpenEditContactCommand
        {
            get
            {
                return openEditContactCommand ?? (
                        new RelayCommand(obj =>
                        {
                            ShowEditContactWindow();
                        }));
            }
        }
        //поле для хранения команды редактирования
        private RelayCommand editContactCommand;
        //
        public RelayCommand EditContactCommand
        {
            get
            {
                return editContactCommand ?? (new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    Contact editContact = new Contact(TextBoxName, TextBoxEmail, TextBoxPhoneNumber);
                    if (contactManager.EditContact(SelectedIndex, editContact))
                    {
                        window.Close();
                    }
                }));
            }
        }

        public RelayCommand removeContactCommand;
        //свойство, предоставляющее доступ к команде удаления контакта
        public RelayCommand RemoveContactCommand
        {
            get
            {
                return removeContactCommand ?? (new RelayCommand(obj =>
                {
                    // if(SelectedIndex > -1)
                    {
                        contactManager.RemoveByIndex(SelectedIndex);
                    }
                }));
            }
        }





    }
}
