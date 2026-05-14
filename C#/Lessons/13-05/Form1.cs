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

        private void ListBox_cards_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_cards.SelectedIndex >= 0)
            {
                bs.Position = listBox_cards.SelectedIndex;
            }
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
            listBox_cards.DataSource = bs;


            //заполнения для ускорения тестирования
            OrgInput.Text = "Top-academy";
            FilInput.Text = "Zapadny";
            CityInput.SelectedIndex = 0;
            PersonCityInput.SelectedIndex = 1;

            // в констркуторе формы1
            //привязка данных
            bs.DataSource = personCards;
            listBox_cards.DataSource = bs;

            listBox_cards.DisplayMember = "Display";

            //привязка элементов
            OrgInput.DataBindings.Add(new Binding("Text", bs, "Organization", false, DataSourceUpdateMode.OnPropertyChanged));
            FilInput.DataBindings.Add(new Binding("Text", bs, "Filial", false, DataSourceUpdateMode.OnPropertyChanged));
            CityInput.DataBindings.Add(new Binding("Text", bs, "FilialCity", false, DataSourceUpdateMode.OnPropertyChanged));

            IdInput.DataBindings.Add("Value", bs, "Id");

            SecNameInput.DataBindings.Add(new Binding("Text", bs, "LastName", false, DataSourceUpdateMode.OnPropertyChanged));
            FirstNameInput.DataBindings.Add(new Binding("Text", bs, "FirstName", false, DataSourceUpdateMode.OnPropertyChanged));
            PatInput.DataBindings.Add(new Binding("Text", bs, "Patronymic", false, DataSourceUpdateMode.OnPropertyChanged));
            CatInput.DataBindings.Add(new Binding("Value", bs, "Category", false, DataSourceUpdateMode.OnPropertyChanged));
            PersonCityInput.DataBindings.Add(new Binding("Text", bs, "AddressCity", false, DataSourceUpdateMode.OnPropertyChanged));
            AddressStrInput.DataBindings.Add(new Binding("Text", bs, "AddressStreet", false, DataSourceUpdateMode.OnPropertyChanged));
        }

        private void ExitButton_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            //собираем данные из полей
            //собираем данные из полей
            string organisation = OrgInput.Text;
            string filial_name = FilInput.Text;
            string filial_city = CityInput.SelectedItem?.ToString() ?? "";

            int id = next_id;
            string last_name = SecNameInput.Text;
            string first_name = FirstNameInput.Text;
            string patronomic = PatInput.Text;
            int kategory = (int)CatInput.Value;
            string person_city = PersonCityInput.SelectedItem?.ToString() ?? "";
            string street = AddressStrInput.Text;
            //Add
            PersonCard card = new PersonCard(organisation, filial_name, filial_city,
                            id, last_name, first_name, patronomic, kategory,
                            person_city, street);


            personCards.Add(card);
            //bs.Add(card);  //либо так
            bs.Position = personCards.Count - 1; //  удержание нового элемента
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
            int index = listBox_cards.SelectedIndex;
            bs.RemoveAt(index);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}
