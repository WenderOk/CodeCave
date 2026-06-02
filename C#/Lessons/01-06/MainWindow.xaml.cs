using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace _01_06
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string path = "contacts.xml";
        public ObservableCollection<Contact> Contacts { get; set; }
        private ContactManager contactManager {  get; set; }
        public MainWindow()
        {
            InitializeComponent();
            contactManager = new ContactManager();
            DataContext = contactManager;
            contactManager.LoadFromFile(path);
        }

        private void ContactsDataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if(ContactsDataGrid.SelectedItem is Contact selectedcontact)
            {
                TextBox_name.Text = selectedcontact.Name;
                TextBox_phone.Text = selectedcontact.PhoneNumber;
                TextBox_email.Text = selectedcontact.Email;
            }
        }

        private void Button_add_Click(object sender, RoutedEventArgs e)
        {
            string name = TextBox_name.Text;
            string phone = TextBox_phone.Text;
            string email = TextBox_email.Text;
            Contact contact = new Contact(name, phone, email);
            if(!contactManager.AddContact(contact)) { }
        }

        private void Button_remove_Click(object sender, RoutedEventArgs e)
        {
            if (ContactsDataGrid.SelectedItem is Contact selectedcontact)
                contactManager.RemoveContact(selectedcontact);
            else
                MessageBox.Show("Элемент для удаления не выбран");
            
        }

        private void Button_edit_Click(object sender, RoutedEventArgs e)
        {
            if(ContactsDataGrid.SelectedItem is Contact selectedcontact)
            {
                int index = ContactsDataGrid.SelectedIndex;
                Contact new_contact = new Contact()
                {
                    Name = TextBox_name.Text,
                    PhoneNumber = TextBox_phone.Text,
                    Email = TextBox_email.Text
                };

                if (!contactManager.EditContact(index, new_contact))
                    MessageBox.Show("Заполнены не все поля");
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            contactManager.SaveToFile(path);
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            contactManager.SaveToFile(path);
        }
    }
}
