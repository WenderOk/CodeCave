using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _06_05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            BindingSource bs = new BindingSource();
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            BindingList<Employ> employees = new BindingList<Employ>()
            {
                new Employ("Степанов Алексей Сергеевич", "директор", 125000),
                new Employ("Феоктистов Федор Владимирович", "директор", 125000),
                new Employ("Степанов Алексей Сергеевич", "директор", 125000),
                new Employ("Степанов Алексей Сергеевич", "директор", 125000),
                new Employ("Степанов Алексей Сергеевич", "директор", 125000),
                new Employ("Степанов Алексей Сергеевич", "директор", 125000)
            };

            bs.DataSource = employees;
            listBox1.DataSource = bs;

            NameInput.DataBindings.Add(new Binding("Text",
                bs, "Name", false, DataSourceUpdateMode.OnPropertyChanged));
            PositionInput.DataBindings.Add(new Binding("Text",
                bs, "Position", false, DataSourceUpdateMode.OnPropertyChanged));
            SalaryInput.DataBindings.Add(new Binding("Value",
                bs, "Salary", false, DataSourceUpdateMode.OnPropertyChanged));
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonExit_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }
    }
}
