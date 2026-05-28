using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _28_05_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string Letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string Digits = "0123456789";
        private const string SpecChars = "!@#$%^&*()_+=-[]{}|;:',.<>?";

        private readonly Random _random = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnGenerate_Click(object sender, RoutedEventArgs e)
        {
            int length = (int)slider_len.Value;
            StringBuilder charPool = new StringBuilder();

            if (checkBox_letters.IsChecked == true) charPool.Append(Letters);
            if (checkBox_digits.IsChecked == true) charPool.Append(Digits);
            if (checkBox_spec.IsChecked == true) charPool.Append(SpecChars);

            StringBuilder password = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                int index = _random.Next(charPool.Length);
                password.Append(charPool[index]);
            }

            textBox_pwd.Text = password.ToString();
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            textBox_pwd.Clear();
        }
    }
}
