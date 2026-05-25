using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PhoneBook
{
    public partial class Form1 : Form
    {
        private bool isEditMode = false;

        public Form1()
        {
            InitializeComponent();
            comboBoxGroup.Items.AddRange(new string[] { "Семья", "Работа", "Друзья" });

            if (!System.IO.File.Exists("pwd.dat")) PasswordManager.SavePassword("1234");

            textBoxName.TextChanged += TextBoxFields_TextChanged;
            textBoxPhone.TextChanged += TextBoxFields_TextChanged;

            SetInterfaceMode(false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDataFromXml();
        }

        // Метод управления доступностью интерфейса
        private void SetInterfaceMode(bool editModeActive)
        {
            isEditMode = editModeActive;

            // Поля ввода доступны только в режиме редактирования
            textBoxName.Enabled = isEditMode;
            textBoxPhone.Enabled = isEditMode;
            comboBoxGroup.Enabled = isEditMode;
            radioButtonMale.Enabled = isEditMode;
            radioButtonFemale.Enabled = isEditMode;

            // Кнопки добавления и удаления доступны только в режиме редактирования
            btnAdd.Enabled = isEditMode;
            btnRemove.Enabled = isEditMode;

            // Кнопка сохранения управляется отдельно функцией валидации ValidateSaveButton()
            ValidateSaveButton();

            // Текст на главной кнопке
            btnEditMode.Text = isEditMode ? "Выйти из ред." : "Войти в ред.";

            // ListView всегда доступен для выбора записей
            listViewContacts.Enabled = true;
        }

        // Динамическая проверка: если поля имени или телефона пусты, или не выбрана запись — сохранять нельзя
        private void TextBoxFields_TextChanged(object sender, EventArgs e)
        {
            ValidateSaveButton();
        }

        private void ValidateSaveButton()
        {
            // Кнопка "Сохранить" активна только в режиме редактирования, 
            // когда выбрана запись в таблице и обязательные поля НЕ пустые
            btnSave.Enabled = isEditMode &&
                             listViewContacts.SelectedItems.Count > 0 &&
                             !string.IsNullOrWhiteSpace(textBoxName.Text) &&
                             !string.IsNullOrWhiteSpace(textBoxPhone.Text);
        }

        // Переключение режима просмотра / редактирования
        private void btnEditMode_Click(object sender, EventArgs e)
        {
            if (!isEditMode)
            {
                using (PasswordForm pwdForm = new PasswordForm())
                {
                    if (pwdForm.ShowDialog() == DialogResult.OK)
                    {
                        SetInterfaceMode(true);
                    }
                }
            }
            else
            {
                SetInterfaceMode(false);
                ClearFields();
                listViewContacts.SelectedItems.Clear();
            }
        }

        // Клик по строке в ListView (Работает и в режиме просмотра, и в режиме редактирования)
        private void listViewContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewContacts.SelectedItems.Count == 0)
            {
                // Если выделение снято — очищаем поля и обновляем доступность кнопки сохранения
                ClearFields();
                ValidateSaveButton();
                return;
            }

            ListViewItem selectedItem = listViewContacts.SelectedItems[0];
            Contact contact = (Contact)selectedItem.Tag;

            // Заполняем поля данными выбранного контакта
            textBoxName.Text = contact.Name;
            textBoxPhone.Text = contact.Phone;
            comboBoxGroup.SelectedItem = contact.Group;

            if (contact.Gender == "М") radioButtonMale.Checked = true;
            else if (contact.Gender == "Ж") radioButtonFemale.Checked = true;
            else { radioButtonMale.Checked = false; radioButtonFemale.Checked = false; }

            // Перепроверяем, можно ли теперь активировать кнопку сохранения
            ValidateSaveButton();
        }

        // ДОБАВЛЕНИЕ ЗАПИСИ
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text) || string.IsNullOrWhiteSpace(textBoxPhone.Text))
            {
                MessageBox.Show("Заполните Имя и Телефон для добавления нового контакта!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string gender = radioButtonMale.Checked ? "М" : (radioButtonFemale.Checked ? "Ж" : "Нет");
            string group = comboBoxGroup.SelectedItem?.ToString() ?? "Нет группы";

            Contact newContact = new Contact(textBoxName.Text.Trim(), textBoxPhone.Text.Trim(), group, gender);

            ListViewItem item = new ListViewItem(newContact.Name);
            item.SubItems.Add(newContact.Phone);
            item.SubItems.Add(newContact.Group);
            item.SubItems.Add(newContact.Gender);
            item.Tag = newContact;

            listViewContacts.Items.Add(item);

            SaveDataToXml();
            ClearFields();
            listViewContacts.SelectedItems.Clear(); // Снимаем выделение, чтобы случайно не перезаписать старый контакт
        }

        // СОХРАНЕНИЕ ИЗМЕНЕНИЙ
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (listViewContacts.SelectedItems.Count == 0) return;

            ListViewItem item = listViewContacts.SelectedItems[0];
            Contact contact = (Contact)item.Tag;

            // Переносим проверенные данные из полей в объект
            contact.Name = textBoxName.Text.Trim();
            contact.Phone = textBoxPhone.Text.Trim();
            contact.Group = comboBoxGroup.SelectedItem?.ToString() ?? "Нет группы";
            contact.Gender = radioButtonMale.Checked ? "М" : "Ж";

            // Обновляем визуальные колонки в ListView
            item.Text = contact.Name;
            item.SubItems[1].Text = contact.Phone;
            item.SubItems[2].Text = contact.Group;
            item.SubItems[3].Text = contact.Gender;

            SaveDataToXml();

            // Очищаем форму для следующего действия, но остаемся в режиме редактирования
            ClearFields();
            listViewContacts.SelectedItems.Clear();
        }

        // УДАЛЕНИЕ ЗАПИСИ
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listViewContacts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите запись для удаления!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dialogResult = MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                listViewContacts.Items.Remove(listViewContacts.SelectedItems[0]);
                SaveDataToXml();
                ClearFields();
            }
        }

        // --- МЕТОДЫ ОЧИСТКИ И ЗАГРУЗКИ ---

        private void ClearFields()
        {
            // Временное отключение событий, чтобы избежать лишних вызовов валидации при полной очистке
            textBoxName.TextChanged -= TextBoxFields_TextChanged;
            textBoxPhone.TextChanged -= TextBoxFields_TextChanged;

            textBoxName.Clear();
            textBoxPhone.Clear();
            comboBoxGroup.SelectedIndex = -1;
            radioButtonMale.Checked = false;
            radioButtonFemale.Checked = false;

            textBoxName.TextChanged += TextBoxFields_TextChanged;
            textBoxPhone.TextChanged += TextBoxFields_TextChanged;
        }

        private void SaveDataToXml()
        {
            List<Contact> list = new List<Contact>();
            foreach (ListViewItem item in listViewContacts.Items)
            {
                if (item.Tag is Contact contact) list.Add(contact);
            }
            XmlManager.SaveContacts(list);
        }

        private void LoadDataFromXml()
        {
            listViewContacts.Items.Clear();
            List<Contact> loaded = XmlManager.LoadContacts();
            foreach (var contact in loaded)
            {
                ListViewItem item = new ListViewItem(contact.Name);
                item.SubItems.Add(contact.Phone);
                item.SubItems.Add(contact.Group);
                item.SubItems.Add(contact.Gender);
                item.Tag = contact;
                listViewContacts.Items.Add(item);
            }
        }
    }
}

