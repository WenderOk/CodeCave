using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _06_05_2
{


    internal class PersonCard: INotifyPropertyChanged
    {
        private string organization;
        private string filial;
        private string filialCity;
        private int id;
        private string lastName;
        private string firstName;
        private string patronymic;
        private int category;
        private string addressCity;
        private string addressStreet;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public string Organization
        {
            get => organization;
            set
            {
                if (organization != value)
                {
                    organization = value;
                    OnPropertyChanged(nameof(Organization));
                    OnPropertyChanged(nameof(Display));
                }
            }
        }

        public string Filial
        {
            get => organization;
            set
            {
                if (organization != value)
                {
                    Filial = value;
                    OnPropertyChanged(nameof(Filial));
                    OnPropertyChanged(nameof(Display));
                }
            }
        }

        public string FilialCity
        {
            get => organization;
            set
            {
                if (organization != value)
                {
                    FilialCity = value;
                    OnPropertyChanged(nameof(FilialCity));
                    OnPropertyChanged(nameof(Display));
                }
            }
        }

        public int Id
        {
            get => Id;
            set
            {
                if (Id != value)
                {
                    Id = value;
                    OnPropertyChanged(nameof(Id));
                    OnPropertyChanged(nameof(Display));
                }
            }
        }

        public string LastName
        {
            get => organization;
            set
            {
                if (organization != value)
                {
                    LastName = value;
                    OnPropertyChanged(nameof(LastName));
                    OnPropertyChanged(nameof(Display));
                }
            }
        }

        public string FirstName
        {
            get => organization;
            set
            {
                if (organization != value)
                {
                    FirstName = value;
                    OnPropertyChanged(nameof(FirstName));
                    OnPropertyChanged(nameof(Display));
                }
            }
        }

        public string Patronymic
        {
            get => organization;
            set
            {
                if (organization != value)
                {
                    Patronymic = value;
                    OnPropertyChanged(nameof(Patronymic));
                    OnPropertyChanged(nameof(Display));
                }
            }
        }

        public int Category
        {
            get => Category;
            set
            {
                if (Category != value)
                {
                    Category = value;
                    OnPropertyChanged(nameof(Category));
                    OnPropertyChanged(nameof(Display));
                }
            }
        }

        public string AddressCity
        {
            get => AddressCity;
            set
            {
                if (AddressCity != value)
                {
                    AddressCity = value;
                    OnPropertyChanged(nameof(AddressCity));
                    OnPropertyChanged(nameof(Display));
                }
            }
        }

        public string AddressStreet
        {
            get => AddressStreet;
            set
            {
                if (AddressStreet != value)
                {
                    AddressStreet = value;
                    OnPropertyChanged(nameof(AddressStreet));
                    OnPropertyChanged(nameof(Display));
                }
            }
        }

        public PersonCard() { }
        public PersonCard(string org, string fil, string filCity, int id, string lName, string fName, string pName, int cat, string addCity, string addStr)
        {
            Organization = org;
            Filial = fil;
            FilialCity = filCity;
            Id = id;
            LastName = lName;
            FirstName = fName;
            Patronymic = pName;
            Category = cat;
            AddressCity = addCity;
            AddressStreet = addStr;
        }
        public override string ToString()
        {
            return $"{Organization} - {Filial} - {FilialCity} " +
                    $"{Id} - {LastName} {FirstName} {Patronymic} " +
                    $"категория {Category} - Прописка {AddressCity}, {AddressStreet}";
        }
        public string Display
        {
            get
            {
                return $"{Organization} - {Filial} - {FilialCity} " +
                    $"{Id} - {LastName} {FirstName} {Patronymic} " +
                    $"категория {Category} - Прописка {AddressCity}, {AddressStreet}";
            }
        }
    }
}
