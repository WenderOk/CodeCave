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
        public Form1()
        {
            personCards = new BindingList<PersonCard>();
            personCards.Add(new PersonCard());
            InitializeComponent();
            SetupComboboxCity(ref CityInput);
            SetupComboboxCity(ref PersonCityInput);

        }

        private void SetupComboboxCity(ref ComboBox CityInput)
        {
            string[] str = { "Выборг", "Санкт-Петербург", "Москва", "Ломоносов", "Павловск", "Гатчина", "Рощино", "Гаврилово",
            "Светогорск", "Гончарово", "Черкасово", "Красный Холм"};
            Array.Sort(str);
            CityInput.Items.AddRange(str);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ExitButton_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }
    }
}
