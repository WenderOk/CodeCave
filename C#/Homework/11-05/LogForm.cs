using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFApp1
{
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
            passField.PasswordChar = '*';
            buttonEnter.Click += (s, e) => Check();
        }

        void Check()
        {
            if (login.Text == "admin" && passField.Text == "123")
                DialogResult = DialogResult.OK;
            else
                MessageBox.Show("Неверно!");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void login_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
