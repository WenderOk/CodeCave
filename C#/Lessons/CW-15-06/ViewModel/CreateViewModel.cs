using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Remoting.Proxies;
using System.Windows.Input;
using CW_15_06.Model;

namespace CW_15_06.ViewModel
{
    internal class CreateViewModel: INotifyPropertyChanged
    {
        private readonly Manager manager;
        private string path = "objects.xml";

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string newObject;
        public string NewObject
        {
            get => newObject;
            set
            {
                newObject = value;
                OnPropertyChange(nameof(NewObject));
            }
        }

        private string newClassification;
        public string NewClassification
        {
            get => newClassification;
            set
            {
                newClassification = value;
                OnPropertyChange(nameof(NewClassification));
            }
        }

        public ICommand AddObjectCommand { get; }
        public ICommand AddClassificationCommand { get; }
        public ICommand ReturnToMainCommand { get; }


        private ObservableCollection<ObservationObject> objects = new ObservableCollection<ObservationObject>();
        public ObservableCollection<ObservationObject> Objects => objects;

        private ObservableCollection<Rating> ratings = new ObservableCollection<Rating>();
        public ObservableCollection<Rating> Ratings
        {
            get => ratings;
            set
            {
                OnPropertyChange(nameof(Ratings));
            }
        }

        private ObservableCollection<Classification> classifications = new ObservableCollection<Classification>();
        public ObservableCollection<Classification> Classifications => classifications;

        public Observation selectedObservation;

        public CreateViewModel()
        {
            manager = new Manager();
            AddObjectCommand = new RelayCommand(_ => AddNewObjectToCombobox());
            AddClassificationCommand = new RelayCommand(_ => AddNewClassificationToCombobox());
            ReturnToMainCommand = new RelayCommand(_ => ReturnToMain());

            Rating r = new Rating();
            ratings = r.Init();
        }

        public void ReturnToMain()
        {
            manager.SaveToXml_objects(path, Objects);
        }

        public void AddNewObjectToCombobox()
        {
            if (string.IsNullOrWhiteSpace(NewObject))
                return;

            ObservationObject o = new ObservationObject();
            o.Id = Objects.Count + 1;
            o.Name = NewObject;
            Objects.Add(o);
            manager.AddObject(o);
            NewObject = string.Empty;
        }

        public void AddNewClassificationToCombobox()
        {
            if (string.IsNullOrWhiteSpace(NewClassification))
                return;

            Classification o = new Classification();
            o.Id = Classifications.Count + 1;
            o.ClassName = NewClassification;
            Classifications.Add(o);
            manager.AddClassification(o);
            NewClassification = string.Empty;
        }
    }
}
