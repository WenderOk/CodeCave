using System;
using System.Windows.Forms;

namespace _27_05_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Fill_comboBox_ingredients();
            radioButton2.Checked = true;
        }

        private void Fill_comboBox_ingredients()
        {
            comboBox_ingredients.Items.AddRange(new string[]
            {
                "картофель", "лук репчатый", "морковь", "свекла", "капуста", "болгарский перец", "кабачок",
                "куриное филе", "рыбное филе", "говядина", "свинина", "кроличье мясо",
                "масло сливочное", "масло подсолнечное", "майонез","томатная паста","томатный соус","уксус",
                "соль", "сахар","перец черный", "перец красный жгучий","зира","кориандр","базилик",
                "рис","макароны","гречневая крупа","булгур","перловая крупа"
            });

            comboBox_ingredients.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox_ingredients.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            string ingredient = comboBox_ingredients.Text.Trim();
            if (string.IsNullOrWhiteSpace(ingredient))
                return;

            // проверка на дубликаты
            if (!listBox_ingredients.Items.Contains(ingredient))
                listBox_ingredients.Items.Add(ingredient);
            
            // если ингредиента нет в ComboBox —
            // добавляем его туда
            if (!comboBox_ingredients.Items.Contains(ingredient))
                comboBox_ingredients.Items.Add(ingredient);
            

            comboBox_ingredients.Text = "";
        }

        private void button_save_Click(object sender, EventArgs e)
        {

        }
    }
}
