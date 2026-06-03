using System;
using System.Collections.Generic;
using System.Windows;
using _03_06.ViewModel;

namespace _03_06
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
        }

        public AddWindow(ContactViewModel contactViewModel)
        {
            InitializeComponent();
            DataContext = contactViewModel;
        }
    }
}
