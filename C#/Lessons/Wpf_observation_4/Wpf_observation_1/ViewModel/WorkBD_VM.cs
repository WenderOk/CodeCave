using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using Wpf_observation_1.Model;

namespace Wpf_observation_1.ViewModel
{
	public class WorkBD_VM : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this,
				new PropertyChangedEventArgs(propertyName));
		}
		private readonly Manager manager;

		
		private int id_number;
		public int Id_number
		{
			get => id_number;
			set
			{
				id_number = value;
				OnPropertyChanged(nameof(Id_number));
			}
		}
		// исходная коллекция
		
		public ObservableCollection<Observation> Observations => manager.Observations;
		
        public ObservableCollection<ObjectOfObservation> Objects => manager.Objects;

        public ObservableCollection<Classification> Classifications => manager.Classifications;

        public ObservableCollection<Rating> Ratings => manager.Ratings;
        // коллекция-представление
        private ICollectionView observationsView;
		public ICollectionView ObservationsView => observationsView;
		
		
		public ICommand RemoveCommand { get; } 
		public ICommand ClearFiltersCommand { get; }
		public ICommand ReturnToMainCommand { get; }
		public ICommand EditCommand { get; }

		// конструктор
        public WorkBD_VM()
        {
			manager = new Manager();
			
			//Создаем представление (view) на основе загруженной коллекции Observations
			observationsView = CollectionViewSource.GetDefaultView(manager.Observations);
			//Назначаем метод-фильтр этому представлению.
			if (observationsView != null) 
			{
				observationsView.Filter = ObservationFilter;
			}
			ClearFiltersCommand = new RelayCommand(_ => ClearFilters());
			RemoveCommand = new RelayCommand(_ => Remove(), _ => SelectedObservation != null);
		}
		
		private void Remove()
		{
			if (SelectedObservation == null)
				return;
			manager.RemoveObservation(SelectedObservation);
		}

		private void ClearFilters()
		{
			SelectedObject = null;
			SelectedClassification = null;
			SelectedRating = null;
		}

		private Observation selectedObservation;

		public Observation SelectedObservation
		{
			get => selectedObservation;
			set
			{
				selectedObservation = value;
				OnPropertyChanged(nameof(SelectedObservation));
			}
		}

		private ObjectOfObservation selectedObject;

		public ObjectOfObservation SelectedObject
		{
			get => selectedObject;
			set
			{
				selectedObject = value;
				OnPropertyChanged(nameof(SelectedObject));
				ApplyFilters();
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
				ApplyFilters();
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
				ApplyFilters();
			}
		}
		private void ApplyFilters()
		{
			// Проверяем, что представление было создано, и вызываем его обновление.
			if (observationsView != null)
			{
				observationsView.Refresh();
			}
		}
		// ЛОГИКА ФИЛЬТРАЦИИ
		private bool ObservationFilter(object item)
		{
			// Проверяем, что элемент является объектом типа Observation.
			// Если нет - сразу исключаем его из отображения.
			if (!(item is Observation obs)) return false;

			// Проверяем фильтры. Если фильтр (SelectedObject) не выбран (null),
			// то условие (SelectedObject == null) становится true, и элемент проходит эту проверку.
			// Если фильтр выбран, проверяется равенство ID.
			bool objectFilterPasses = SelectedObject == null || obs.Object.Id == SelectedObject.Id;
			bool classifFilterPasses = SelectedClassification == null || obs.Classification.Id == SelectedClassification.Id;
			bool ratingFilterPasses = SelectedRating == null || obs.Rating.Id == SelectedRating.Id;

			// Возвращаем true, только если элемент прошел ВСЕ три фильтра.
			return objectFilterPasses && classifFilterPasses && ratingFilterPasses;
		}
	}
}
