using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFApp1
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LogForm form = new LogForm();
            if (form.ShowDialog() == DialogResult.OK)
                MessageBox.Show("Добро пожаловать!");
            else
                Application.Exit();
        }
    }
}
