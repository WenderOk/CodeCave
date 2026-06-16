using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Remoting.Proxies;
using System.Windows;
using System.Windows.Input;
using CW_15_06.Model;

namespace CW_15_06.ViewModel
{
    internal class CreateViewModel: INotifyPropertyChanged
    {
        private readonly Manager manager;
        private string pathObjects = "objects.xml";
        private string pathClassification = "classifications.xml";
        private string pathObservations = "observations.xml";

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

        private string observationText;
        public string ObservationText
        {
            get => observationText;
            set
            {
                observationText = value;
                OnPropertyChange(nameof(ObservationText));
            }
        }

        private ObservationObject selectedObject;
        public ObservationObject SelectedObject
        {
            get => selectedObject;
            set
            {
                selectedObject = value;
                OnPropertyChange(nameof(SelectedObject));
            }
        }

        private Classification selectedClassification;
        public Classification SelectedClassification
        {
            get => selectedClassification;
            set
            {
                selectedClassification = value;
                OnPropertyChange(nameof(SelectedClassification));
            }
        }

        private Rating selectedRating;
        public Rating SelectedRating
        {
            get => selectedRating;
            set
            {
                selectedRating = value;
                OnPropertyChange(nameof(SelectedRating));
            }
        }

        private int id_number;
        public int Id_number
        {
            get => id_number;
            set
            {
                id_number = value;
                OnPropertyChange(nameof(Id_number));
            }
        }

        public ICommand AddObjectCommand { get; }
        public ICommand AddClassificationCommand { get; }
        public ICommand ReturnToMainCommand { get; }
        public ICommand SaveObservationCommand { get; }


        private ObservableCollection<ObservationObject> objects = new ObservableCollection<ObservationObject>();
        public ObservableCollection<ObservationObject> Objects => objects;

        private ObservableCollection<Rating> ratings = new ObservableCollection<Rating>();
        public ObservableCollection<Rating> Ratings
        {
            get => ratings;
            set
            {
                ratings = value;
                OnPropertyChange(nameof(Ratings));
            }
        }

        private ObservableCollection<Classification> classifications = new ObservableCollection<Classification>();
        public ObservableCollection<Classification> Classifications => classifications;

        private ObservableCollection<Observation> observations;

        public string date { get; set; }
    

        public CreateViewModel()
        {
            manager = new Manager();
            AddObjectCommand = new RelayCommand(_ => AddNewObjectToCombobox());
            AddClassificationCommand = new RelayCommand(_ => AddNewClassificationToCombobox());
            ReturnToMainCommand = new RelayCommand(_ => ReturnToMain());
            SaveObservationCommand = new RelayCommand(_ => SaveObservation());

            objects = manager.LoadFromFile_objects(pathObjects);
            classifications = manager.LoadFromFile_classification(pathClassification);
            observations = manager.LoadFromFile_observations(pathObservations);

            Rating r = new Rating();
            ratings = r.Init();

            DateTime d = DateTime.Now;
            date = $"{d.Day}.{d.Month}.{d.Year}";

            observations = new ObservableCollection<Observation>();
            observations = manager.LoadFromFile_observations(pathObservations);
            id_number = observations.Count+1;
        }

        public void SaveObservation()
        {
            DateTime d = DateTime.Now;
            Observation newObs = new Observation(id_number, selectedObject, d.Day, d.Month, d.Year, selectedClassification, observationText, selectedRating );
            observations.Add(newObs);
            manager.AddObservation(newObs);
        }

        public void ReturnToMain()
        {
            manager.SaveToXml_objects(pathObjects, objects);
            manager.SaveToXml_classification(pathClassification, classifications);
            manager.SaveToXml_observations(pathObservations, observations);
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
