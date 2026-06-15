using System;
using System.Collections.Generic;
using System.Windows.Input;
using CW_15_06.Model;
using CW_15_06.View;

namespace CW_15_06.ViewModel
{
    public class MainViewModel
    {
        public ICommand OpenCreateWindowCommand { get; set; }
        public ICommand OpenManageDBCommand { get; set; }

        public MainViewModel()
        {
            OpenCreateWindowCommand = new RelayCommand(_ => OpenCreateObservation());
            OpenManageDBCommand = new RelayCommand(_ => OpenManageDB());
        }

        private void OpenCreateObservation()
        {
            CreateWindow window = new CreateWindow();
            window.Show();
        }
        private void OpenManageDB()
        {
            ManageDatabaseWindow window = new ManageDatabaseWindow();
            window.Show();
        }
    }
}
