namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        private string loginP = "admin";
        private string passwordP = "admin";

        public Form1()
        {
            InitializeComponent();
            Size = new Size(900, 190);
            StartPosition = FormStartPosition.CenterScreen;

            var autoComplete = new AutoCompleteStringCollection();
            autoComplete.AddRange(new string[] { "Космос", "Альфа", "Контент", "Англия", "Коралл" });
            TextBox_projectName.AutoCompleteCustomSource = autoComplete;
            TextBox_projectName.AutoCompleteMode = AutoCompleteMode.Suggest;
            TextBox_projectName.AutoCompleteSource = AutoCompleteSource.CustomSource;

            ComboBox_type.Items.AddRange(new string[] { "Семинар", "Праздник", "Выставка", "Открытый урок" });
            ComboBox_type.SelectedIndex = 0;

            ToggleElements(false);
        }

        private void ToggleElements(bool show)
        {
            label3.Visible = show;
            TextBox_projectName.Visible = show;
            label4.Visible = show;
            MaskedTextBox_projectDate.Visible = show;
            label5.Visible = show;
            ComboBox_type.Visible = show;
            radioButton1.Visible = show;
            radioButton2.Visible = show;
            label6.Visible = show;
            textBox4.Visible = show;
            listBox1.Visible = show;
            Button_save.Visible = show;
            groupBox1.Visible = show;
            linkLabel1.Visible = show;
            checkBox1.Visible = show;
        }

        private void Button_accept_Click(object sender, EventArgs e)
        {
            if (TextBox_login.Text == loginP && TextBox_pasword.Text == passwordP)
            {
                Size = new Size(900, 700);
                TextBox_login.ReadOnly = true;
                TextBox_pasword.Enabled = false;
                ToggleElements(true);
            }
            else
                MessageBox.Show("Неверный логин или пароль!");
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("https://google.com") { UseShellExecute = true }); }

        private void Button_save_Click(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                MessageBox.Show("Подтвердите условия!");
                return;
            }

            if (string.IsNullOrWhiteSpace(TextBox_projectName.Text))
            {
                MessageBox.Show("Введите название проекта!");
                return;
            }

            listBox1.Items.Add($"{TextBox_projectName.Text} | {MaskedTextBox_projectDate.Text} | {ComboBox_type.SelectedItem} | {(radioButton1.Checked ? "online" : "offline")} | {textBox4.Text}");

            TextBox_projectName.Clear();
            MaskedTextBox_projectDate.Clear();
            textBox4.Clear();
            checkBox1.Checked = false;
            radioButton1.Checked = true;
            ComboBox_type.SelectedIndex = 0;
        }
    }
}