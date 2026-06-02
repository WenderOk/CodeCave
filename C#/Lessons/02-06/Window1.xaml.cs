using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;


namespace _02_06
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1(ObservableCollection<CheckMoney> operationList, string expence)
        {
            InitializeComponent();
            ListBoxCheckMoney.ItemsSource = operationList;
            TextBoxSum.Text = expence;
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
