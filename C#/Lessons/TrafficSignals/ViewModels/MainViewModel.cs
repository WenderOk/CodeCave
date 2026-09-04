using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using TrafficSignals.Models;
using TrafficSignals.Views;

namespace TrafficSignals.ViewModels
{
    internal class MainViewModel
    {
        public ICommand OpenTestCommand { get; }
        public ICommand ExitCommand { get; }

        public MainViewModel()
        {
            OpenTestCommand = new RelayCommand(param => OpenTestWindow(param));
            ExitCommand = new RelayCommand(param => Application.Current.Shutdown());
        }

        private void OpenTestWindow(object currentWindow)
        {
            TestView testWindow = new TestView();
            testWindow.Show();

            if (currentWindow is Window window)
            {
                window.Close();
            }
        }
    }
}
