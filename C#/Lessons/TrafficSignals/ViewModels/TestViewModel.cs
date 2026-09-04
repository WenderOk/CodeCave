using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;
using TrafficSignals.Models;

namespace TrafficSignals.ViewModels
{
    public class TestViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int currentIndex = 0;

        private Brush redLight;
        private Brush yellowLight;
        private Brush greenLight;

        public ObservableCollection<Light> States { get; set; }

        public ICommand SwitchCommand { get; }

        public string CurrentName => States[currentIndex].Name;
        public string CurrentDescription => States[currentIndex].Description;

        public Brush RedLight
        {
            get => redLight;
            set
            {
                redLight = value;
                OnPropertyChanged(nameof(RedLight));
            }
        }

        public Brush YellowLight
        {
            get => yellowLight;
            set
            {
                yellowLight = value;
                OnPropertyChanged(nameof(YellowLight));
            }
        }

        public Brush GreenLight
        {
            get => greenLight;
            set
            {
                greenLight = value;
                OnPropertyChanged(nameof(GreenLight));
            }
        }

        public TestViewModel()
        {
            InitializeStates();

            UpdateLightsColor();

            SwitchCommand = new RelayCommand(param => SwitchLight());
        }

        private void InitializeStates()
        {
            States = new ObservableCollection<Light>
            {
                new Light { Id = 1, Name = "Красный", Description = "Стойте!" },
                new Light { Id = 2, Name = "Желтый", Description = "Внимание!" },
                new Light { Id = 3, Name = "Зеленый", Description = "Движение разрешено!" },
                new Light { Id = 4, Name = "Желтый", Description = "Приготовьтесь к остановке." }
            };
        }

        private void SwitchLight()
        {
            currentIndex = (currentIndex + 1) % States.Count;

            UpdateLightsColor();

            OnPropertyChanged(nameof(CurrentName));
            OnPropertyChanged(nameof(CurrentDescription));
        }

        private void UpdateLightsColor()
        {
            Brush offColor = Brushes.LightGray;

            switch (currentIndex)
            {
                case 0: 
                    RedLight = Brushes.Red;
                    YellowLight = offColor;
                    GreenLight = offColor;
                    break;

                case 1: 
                    RedLight = offColor;
                    YellowLight = Brushes.Yellow;
                    GreenLight = offColor;
                    break;

                case 2: 
                    RedLight = offColor;
                    YellowLight = offColor;
                    GreenLight = Brushes.Green;
                    break;

                case 3: 
                    RedLight = offColor;
                    YellowLight = Brushes.Yellow;
                    GreenLight = offColor;
                    break;
            }
        }
    }
}
