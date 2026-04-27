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

            this.passField.Size = new Size(this.passField.Size.Width, 64);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
