using System;
using System.Drawing;
using System.Windows.Forms;

namespace PhoneBook
{
    public partial class PasswordForm : Form
    {
        public PasswordForm()
        {
            InitializeComponent();
            Size = new Size(450, 250);
        }

        private void Btn_confirmPwd_Click(object sender, EventArgs e)
        {
            if (PasswordManager.VerifyPassword(textBoxPwd.Text))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
                MessageBox.Show("Неверный пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
