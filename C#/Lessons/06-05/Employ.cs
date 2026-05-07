using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_05
{
    public class Employ : INotifyPropertyChanged
    {
        private string name;
        private string position;
        private int salary;

        public string Name
        {
            get { return name; }
            set
            {
                if (name != value) name = value;
                OnPropertyChanged();
            }
        }
        public string Position
        {
            get { return position; }
            set
            {
                if (position != value) position = value;
                OnPropertyChanged();
            }
        }
        public int Salary
        {
            get { return salary; }
            set
            {
                if (salary != value) salary = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Employ(string name, string position, int salary)
        {
            this.name = name;
            this.position = position;
            this.salary = salary;
        }

        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return $"{Name} - {Position} - {Salary}";
        }
    }
}