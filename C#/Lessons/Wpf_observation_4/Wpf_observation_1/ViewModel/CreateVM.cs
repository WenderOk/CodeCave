using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Wpf_observation_1.Model;
using Wpf_observation_1.View;


namespace Wpf_observation_1.ViewModel
{
	public class CreateVM : INotifyPropertyChanged
	{
		private readonly Manager manager;
		
		
		private int id_number;
		public  int Id_number 
		{	get => id_number;
			set 
			{
				id_number = value;
				OnPropertyChanged(nameof(Id_number));
			} 
		}

		private ObservableCollection<Observation> observations = new ObservableCollection<Observation>();
		public ObservableCollection<Observation> Observations => manager.Observations;

		private ObservableCollection<ObjectOfObservation> objects = new ObservableCollection<ObjectOfObservation>();
		public ObservableCollection<ObjectOfObservation> Objects => manager.Objects;

		private ObservableCollection<Classification> classifications = new ObservableCollection<Classification>();
		public ObservableCollection<Classification> Classifications => manager.Classifications;

		private ObservableCollection<Rating> ratings = new ObservableCollection<Rating>();
		public ObservableCollection<Rating> Rating => manager.Ratings;
	
		

		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this,
				new PropertyChangedEventArgs(propertyName));
		}

		

		private string newObject;
		public string NewObject 
		{   get => newObject;
			set
			{ 
			newObject = value;
				OnPropertyChanged(nameof(NewObject));
			}
		}
		private string newClassification;
		public string NewClassification
		{
			get => newClassification;
			set
			{ 
			newClassification = value;
				OnPropertyChanged(nameof(NewClassification));
			}
		}

		private string newText;
		public string NewText
		{
			get => newText; 
			set
			{
				newText = value;
				OnPropertyChanged(nameof(NewText));
			}
		}
		
		public string d {  get; set; }
		
		public ICommand AddObjectCommand { get; }
		public ICommand AddClassificationCommand { get; }
		public ICommand SaveCommand { get; }
		public ICommand ReturnToMainCommand { get; } 
        
		// конструктор
		public CreateVM()
        {
			manager = new Manager();
			
           	AddObjectCommand = new RelayCommand(_ => AddNewObjektToCombobox());		
			AddClassificationCommand = new RelayCommand(_ => AddClassificationToCombobox());
            SaveCommand = new RelayCommand(_ => SavePage());
            ReturnToMainCommand = new RelayCommand(_ => ExitToMain());			
			SelectedRating = Rating[2];
			

			DateTime date = DateTime.Now;
			d = $"{date.Day.ToString()} . {date.Month.ToString()} . {date.Year.ToString()}";

			Id_number =manager.Observations.Count+1;

			
		}
		public void ExitToMain()
		{
			manager.SaveToXml();
			manager.SaveToXml_classification();
			manager.SaveToXml_objects();
			
			
		}
		public void SavePage()
		{			
			DateTime date = DateTime.Now;
			string day = date.Day.ToString();
			string month = date.Month.ToString();
			string year = date.Year.ToString();
			Observation o = new Observation(id_number, selectedObject, selectedClassification, newText, selectedRating);
			manager.AddObservation(o);
			
			Id_number++;   // Вызываем сеттер публичного свойства.
			
			ClearFields();
		}
		public void ClearFields() 
		{ 
			NewObject=string.Empty;
			NewClassification = string.Empty;
			NewText = string.Empty;
			SelectedObject=null;
			SelectedClassification = null;
			SelectedRating =  Rating[2];
			
		}
		public void AddNewObjektToCombobox()
		{
			if (string.IsNullOrWhiteSpace(NewObject))
				return;

			ObjectOfObservation o = new ObjectOfObservation();
			o.Id = Objects.Count + 1;
			o.Name = NewObject;			
			manager.Add_object(o);
			NewObject =string.Empty;
			
		}

		public void AddClassificationToCombobox()
		{
			if (string.IsNullOrWhiteSpace(NewClassification))
				return;
			Classification classif = new Classification();
			classif.Id = classifications.Count + 1;
			classif.ClassificationName = NewClassification;			
			manager.Add_Classification(classif);
			NewClassification = string.Empty;
		}

		



		private ObjectOfObservation selectedObject;

		public ObjectOfObservation SelectedObject
		{
			get => selectedObject;
			set
			{
				selectedObject = value;
				OnPropertyChanged(nameof(Object));
			}
		}

		private Classification selectedClassification;
		public Classification SelectedClassification
		{
			get => selectedClassification;
			set
			{			
				selectedClassification = value;
				OnPropertyChanged(nameof(SelectedClassification));
			}
		}
		private Rating selectedRating;
		public Rating SelectedRating
		{
			get => selectedRating;
			set
			{
				selectedRating = value;
				OnPropertyChanged(nameof(SelectedRating));
			}
		}


	}
}
