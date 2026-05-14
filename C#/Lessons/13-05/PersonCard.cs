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
            get => filial;
            set
            {
                if (filial != value)
                {
                    filial = value;
                    OnPropertyChanged(nameof(Filial));
                    OnPropertyChanged(nameof(Display));
                }
            }
        }

        public string FilialCity
        {
            get => filialCity;
            set
            {
                if (filialCity != value)
                {
                    filialCity = value;
                    OnPropertyChanged(nameof(FilialCity));
                    OnPropertyChanged(nameof(Display));
                }
            }
        }

        public int Id
        {
            get => id;
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged(nameof(Id));
                    OnPropertyChanged(nameof(Display));
                }
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {
                if (lastName != value)
                {
                    lastName = value;
                    OnPropertyChanged(nameof(LastName));
                    OnPropertyChanged(nameof(Display));
                }
            }
        }

        public string FirstName
        {
            get => firstName;
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    OnPropertyChanged(nameof(FirstName));
                    OnPropertyChanged(nameof(Display));
                }
            }
        }

        public string Patronymic
        {
            get => patronymic;
            set
            {
                if (patronymic != value)
                {
                    patronymic = value;
                    OnPropertyChanged(nameof(Patronymic));
                    OnPropertyChanged(nameof(Display));
                }
            }
        }

        public int Category
        {
            get => category;
            set
            {
                if (category != value)
                {
                    category = value;
                    OnPropertyChanged(nameof(Category));
                    OnPropertyChanged(nameof(Display));
                }
            }
        }

        public string AddressCity
        {
            get => addressCity;
            set
            {
                if (addressCity != value)
                {
                    addressCity = value;
                    OnPropertyChanged(nameof(AddressCity));
                    OnPropertyChanged(nameof(Display));
                }
            }
        }

        public string AddressStreet
        {
            get => addressStreet;
            set
            {
                if (addressStreet != value)
                {
                    addressStreet = value;
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
