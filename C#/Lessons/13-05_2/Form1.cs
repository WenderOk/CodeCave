using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _06_05_2
{
    public partial class Form1 : Form
    {
        public static int next_id = 1;
        private BindingList<PersonCard> personCards = new BindingList<PersonCard>();
        private BindingSource bs = new BindingSource();

        private void listView_cards_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (!e.IsSelected) return;

            var p = (PersonCard)e.Item.Tag;
            LoadPersonToInputs(p);
        }

        private void LoadPersonToInputs(PersonCard p)
        {
            OrgInput.Text = p.Organization;
            FilInput.Text = p.Filial;
            CityInput.Text = p.FilialCity;
            IdInput.Value = p.Id;
            SecNameInput.Text = p.LastName;
            FirstNameInput.Text = p.FirstName;
            PatInput.Text = p.Patronymic;
            CatInput.Value = p.Category;
            PersonCityInput.Text = p.AddressCity;
            AddressStrInput.Text = p.AddressStreet;
        }

        private void SetupComboboxCity(ref ComboBox CityInput)
        {
            string[] str = { "Выборг", "Санкт-Петербург", "Москва", "Ломоносов", "Павловск", "Гатчина", "Рощино", "Гаврилово",
            "Светогорск", "Гончарово", "Черкасово", "Красный Холм"};
            Array.Sort(str);
            CityInput.Items.AddRange(str);

        }

        public Form1()
        {
            personCards = new BindingList<PersonCard>();
            personCards.Add(new PersonCard("Компания ТОП",
                "Сев-Зап", "Выб", next_id, "Иванов", "Петр", "Сергеевич",
                2, "в", "Мира 5"));
            next_id++;
            personCards.Add(new PersonCard("Компания ТОП", "Сев-Зап", "Выб", next_id, "Иванов2", "Петр", "Сергеевич", 2, "в", "Мира 5"));
            next_id++;
            personCards.Add(new PersonCard("Компания ТОП", "Сев-Зап", "Выб", next_id, "Иванов3", "Петр", "Сергеевич", 2, "в", "Мира 5"));
            next_id++;
            personCards.Add(new PersonCard("Компания ТОП", "Сев-Зап", "Выб", next_id, "Иванов4", "Петр", "Сергеевич", 2, "в", "Мира 5"));
            next_id++;
            InitializeComponent();
            SetupComboboxCity(ref CityInput);
            SetupComboboxCity(ref PersonCityInput);
            IdInput.Value = next_id;


            //привязка данных
            bs.DataSource = personCards;
            //listView_cards. = bs;


            //заполнения для ускорения тестирования
            listView_cards.View = View.Details;
            listView_cards.FullRowSelect = true;
            listView_cards.GridLines = true;
            listView_cards.MultiSelect = false;


            listView_cards.Columns.Add("Организация", 50);
            listView_cards.Columns.Add("Город", 50);
            listView_cards.Columns.Add("ID", 35);
            listView_cards.Columns.Add("Фамилия", 90);
            listView_cards.Columns.Add("Имя", 90);
            listView_cards.Columns.Add("Отчество", 100);
            listView_cards.Columns.Add("Категория", 35);
            listView_cards.Columns.Add("город", 100);
            listView_cards.Columns.Add("ул. д.", 100);



            // вызов метода обновления
            RefreshListView();

            listView_cards.SelectedItems.Clear();

            // очистить поля
            ClearFields();
        }

        private void RefreshListView()
        {
            listView_cards.Items.Clear();

            foreach (var p in personCards)
            {
                // первую колонку так
                var item = new ListViewItem(p.Organization);
                // остальные колонки так
                item.SubItems.Add(p.FilialCity);
                item.SubItems.Add(p.Id.ToString());
                item.SubItems.Add(p.LastName);
                item.SubItems.Add(p.FirstName);
                item.SubItems.Add(p.Patronymic);
                item.SubItems.Add(p.Category.ToString());
                item.SubItems.Add(p.AddressCity);
                item.SubItems.Add(p.AddressStreet);

                item.Tag = p; // очень важно! Это позволит потом получить объект

                listView_cards.Items.Add(item);

                //выделяем добавленную строку
                //listView_cards.Items[listView_cards.Items.Count - 1].Selected = true;
                //listView_cards.Select();
            }
        }


        private void ExitButton_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            PersonCard p = new PersonCard();
            //собираем данные из полей
            p.Organization = OrgInput.Text;
            p.Filial = FilInput.Text;
            p.FilialCity = CityInput.SelectedItem?.ToString() ?? "";

            p.Id = next_id;
            p.LastName = SecNameInput.Text;
            p.FirstName = FirstNameInput.Text;
            p.Patronymic = PatInput.Text;
            p.Category = (int)CatInput.Value;
            p.AddressCity = CityInput.SelectedItem?.ToString() ?? "";
            p.AddressStreet = AddressStrInput.Text;
            //Add
            PersonCard card = new PersonCard(p.Organization, p.Filial, p.FilialCity,
                            p.Id, p.LastName, p.FirstName, p.Patronymic, p.Category,
                            p.AddressCity, p.AddressStreet);


            personCards.Add(p);
            RefreshListView();
            next_id++;

            ClearFields();
        }

        public void ClearFields()
        {
            OrgInput.Clear();
            FilInput.Clear();
            IdInput.Value = next_id;
            SecNameInput.Clear();
            FirstNameInput.Clear();
            PatInput.Clear();
            AddressStrInput.Clear();
            //заполнения для ускорения тестирования
            OrgInput.Text = "Top-academy";
            FilInput.Text = "Zapadny";
            CityInput.SelectedIndex = 0;
            PersonCityInput.SelectedIndex = 1;
        }



        public void ChangeVisibility(bool visible)
        {
            AddButton.Visible = visible;
            ClearButton.Visible = visible;
            RemoveButton.Visible = visible;
            ExitButton.Visible = visible;
        }


        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (listView_cards.SelectedItems.Count == 0)
            {
                MessageBox.Show("Объект не выбран");
                return;
            }

            var result = MessageBox.Show("Удалить запись?", "Подтверждение",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            var item = listView_cards.SelectedItems[0];
            var p = (PersonCard)item.Tag;

            // 1. удаляем из списка (главное!)
            personCards.Remove(p);

            // 2. удаляем из ListView
            listView_cards.Items.Remove(item);
            // очистим поля
            ClearFields();
        }


        private void SaveButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (listView_cards.SelectedItems.Count == 0)
                return;


            var item = listView_cards.SelectedItems[0];
            var p = (PersonCard)item.Tag;

            // обновляем объект
            p.Organization = OrgInput.Text;
            p.Filial = FilInput.Text;
            p.FilialCity = CityInput.SelectedItem?.ToString() ?? "";

            p.Id = (int)IdInput.Value;
            p.LastName = SecNameInput.Text;
            p.FirstName = FirstNameInput.Text;
            p.Patronymic = PatInput.Text;
            p.Category = (int)CatInput.Value;
            p.AddressCity = PersonCityInput.SelectedItem?.ToString() ?? "";
            p.AddressStreet = AddressStrInput.Text;

            // обновляем строки по индексам
            item.SubItems[0].Text = p.Organization;
            item.SubItems[1].Text = p.FilialCity;
            item.SubItems[2].Text = p.Id.ToString();       // даже если не меняется — можно оставить
            item.SubItems[3].Text = p.LastName;
            item.SubItems[4].Text = p.FirstName;
            item.SubItems[5].Text = p.Patronymic;
            item.SubItems[6].Text = p.Category.ToString();
            item.SubItems[7].Text = p.AddressCity;
            item.SubItems[8].Text = p.AddressStreet;

            ChangeVisibility(true);
        }

        private void EditButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (listView_cards.SelectedItems.Count == 0)
            {
                MessageBox.Show("Объект не выбран");
                return;
            }

            PersonCard p = (PersonCard)listView_cards.SelectedItems[0].Tag;
            LoadPersonToInputs(p);
            ChangeVisibility(false );
        }

        private void RemoveButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (listView_cards.SelectedItems.Count == 0)
            {
                MessageBox.Show("Объект не выбран");
                return;
            }

            var result = MessageBox.Show("Удалить запись?", "Подтверждение",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            var item = listView_cards.SelectedItems[0];
            var p = (PersonCard)item.Tag;

            // 1. удаляем из списка (главное!)
            personCards.Remove(p);

            // 2. удаляем из ListView
            listView_cards.Items.Remove(item);
            // очистим поля
            ClearFields();
        }

        private void ClearButton_MouseClick(object sender, MouseEventArgs e)
        {
            ClearFields();
        }
    }
}
