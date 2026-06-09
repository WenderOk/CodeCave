using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using _03_06.Model;

namespace _03_06.ViewModel
{
    public class ContactViewModel
    {
        private ContactManager contactManager = new ContactManager();
        public string TextBoxName { get; set; }
        public string TextBoxEmail { get; set; }
        public string TextBoxPhone { get; set; }
        public void SetTextBox(string name, string email, string phone)
        {
            TextBoxName = name;
            TextBoxEmail = email;
            TextBoxPhone = phone;
        }
        public ContactViewModel()
        {
            contactManager.LoadContacts("Contacts.xml");
        }
        public ObservableCollection<Contact> Contacts { get { return contactManager.Contacts; } }
        private void ShowAddContactWindow()
        {
            AddWindow addWindow = new AddWindow(this);
            SetTextBox("default", "default@mail.com", "+7 999 999 99 99");
            addWindow.ShowDialog();
        }

        private RelayCommand openAddContactCommand;

        public RelayCommand OpenAddContactCommand
        {
            get 
            {
                return openAddContactCommand ?? (
                    new RelayCommand(obj => { ShowAddContactWindow(); }));
            }
        }

        private RelayCommand addContactCommand;
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
                                                                 TextBoxPhone)))
                        {
                            window.Close();
                        }
                    }
                    )
                );
            }
        }

    }
}
