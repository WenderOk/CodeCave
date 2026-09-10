using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace _10_09
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            myProc.StartInfo = new System.Diagnostics.ProcessStartInfo("calc.exe");
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            myProc.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            //myProc.CloseMainWindow();
            //myProc.Close();
            Process[] procArr = Process.GetProcessesByName("CalculatorApp");
            if (procArr.Length > 0)
                procArr[0].Kill();
            else
                MessageBox.Show("Cannt find opened calculator window");
        }
    }
}
