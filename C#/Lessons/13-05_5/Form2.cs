using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _13_05_5
{
    public partial class Form2 : Form
    {
        public Person NewPerson { get; set; }
        private Person EditingPerson;
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(Person p)
        {
            InitializeComponent();

            EditingPerson = p;

            textBox_lastName.Text = p.LastName;
            textBox_firstName.Text = p.FirstName;
            textBox_patronomic.Text = p.Patronomic;
            textBox_certnum.Text = p.CertificateNumber;
        }

        private void button_return_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            if (EditingPerson == null)
            {
                // режим ДОБАВЛЕНИЯ
                NewPerson = new Person()
                {
                    LastName = textBox_lastName.Text,
                    FirstName = textBox_firstName.Text,
                    Patronomic = textBox_patronomic.Text,
                    CertificateNumber = textBox_certnum.Text
                };

            }
            else
            {
                // режим РЕДАКТИРОВАНИЯ
                EditingPerson.LastName = textBox_lastName.Text;
                EditingPerson.FirstName = textBox_firstName.Text;
                EditingPerson.Patronomic = textBox_patronomic.Text;
                EditingPerson.CertificateNumber = textBox_certnum.Text;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
