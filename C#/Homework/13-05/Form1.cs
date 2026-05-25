using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
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
                bs.Position = listBox_cards.SelectedIndex;
        }

        private void SetupComboboxCity(ref ComboBox cityInput)
        {
            List<string> cities = new List<string>();

            if (File.Exists("Cities.txt"))
                cities.AddRange(File.ReadAllLines("Cities.txt"));
            
            else
            {
                // Если файла нет — создаём с дефолтным списком
                string[] defaultCities =
                {
                    "Выборг", "Санкт-Петербург", "Москва", "Ломоносов",
                    "Павловск", "Гатчина", "Рощино", "Гаврилово",
                    "Светогорск", "Гончарово", "Черкасово", "Красный Холм"
                };
                File.WriteAllLines("Cities.txt", defaultCities);
                cities.AddRange(defaultCities);
            }

            cities.Sort();
            cityInput.Items.Clear();
            cityInput.Items.AddRange(cities.ToArray());
        }

        public Form1()
        {
            InitializeComponent();

            // Заполнение ComboBox городами из файла
            SetupComboboxCity(ref CityInput);
            SetupComboboxCity(ref PersonCityInput);

            // Загрузка данных из XML
            personCards = PersonCard.LoadFromXml("Persons.xml");
            if (personCards.Count == 0)
            {
                personCards.Add(new PersonCard("Компания ТОП", "Сев-Зап", "Выб", next_id, "Иванов2", "Петр", "Сергеевич", 2, "в", "Мира 5"));
                next_id++;
                personCards.Add(new PersonCard("Компания ТОП", "Сев-Зап", "Выб", next_id, "Иванов3", "Петр", "Сергеевич", 2, "в", "Мира 5"));
                next_id++;
                personCards.Add(new PersonCard("Компания ТОП", "Сев-Зап", "Выб", next_id, "Иванов4", "Петр", "Сергеевич", 2, "в", "Мира 5"));
                next_id++;
                personCards.Add(new PersonCard("Компания ТОП", "Сев-Зап", "Выб", next_id, "Иванов4", "Петр", "Сергеевич", 2, "в", "Мира 5"));
            }

            // Вычисление next_id как максимальный Id + 1
            next_id = (personCards.Count > 0) ? personCards.Max(c => c.Id) + 1 : 1;
            IdInput.Value = next_id;

            // Привязка данных
            bs.DataSource = personCards;
            listBox_cards.DataSource = bs;
            listBox_cards.DisplayMember = "Display";

            // Вспомогательная установка полей для ускорения тестирования
            OrgInput.Text = "Top-academy";
            FilInput.Text = "Zapadny";
            if (CityInput.Items.Count > 0) CityInput.SelectedIndex = 0;
            if (PersonCityInput.Items.Count > 0) PersonCityInput.SelectedIndex = 1;
        }

        private void SaveData()
        {
            PersonCard.SaveToXml(personCards, "Persons.xml");
        }

        private void ExitButton_MouseClick(object sender, MouseEventArgs e)
        {
            SaveData();
            Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
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

            listBox_cards.DisplayMember = "Display";
            personCards.Add(card);
            //bs.Add(card);  //либо так

            bs.Position = personCards.Count - 1; // 🔥 ключевая строка
            next_id++;
            SaveData();
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

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (listBox_cards.SelectedItem is PersonCard card)
            {
                OrgInput.Text = card.Organization;
                FilInput.Text = card.Filial;
                CityInput.Text = card.FilialCity;
                IdInput.Value = card.Id;
                SecNameInput.Text = card.LastName;
                FirstNameInput.Text = card.FirstName;
                PatInput.Text = card.Patronymic;
                CatInput.Value = card.Category;
                PersonCityInput.Text = card.AddressCity;
                AddressStrInput.Text = card.AddressStreet;

                ChangeVisibility(false);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            int index = listBox_cards.SelectedIndex;
            //MessageBox.Show($"{index}");
            string organisation = OrgInput.Text;
            string filial_name = FilInput.Text;
            string filial_city = CityInput.SelectedItem?.ToString() ?? "";
            int id = (int)IdInput.Value;
            //int id = next_id;
            string last_name = SecNameInput.Text;
            string first_name = FirstNameInput.Text;
            string patronomic = PatInput.Text;
            int kategory = (int)CatInput.Value;
            string person_city = PersonCityInput.SelectedItem?.ToString() ?? "";
            string street = AddressStrInput.Text;

            PersonCard card = new PersonCard(organisation, filial_name, filial_city,
                            id, last_name, first_name, patronomic, kategory,
                            person_city, street);

            bs.RemoveAt(index);
            bs.Insert(index, card);

            ChangeVisibility(true);
            SaveData();
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
            SaveData();
        }
    }
}
