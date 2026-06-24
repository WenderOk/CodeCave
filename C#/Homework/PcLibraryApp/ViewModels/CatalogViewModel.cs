using PcLibraryApp.Infrastructure;
using PcLibraryApp.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace PcLibraryApp.ViewModels
{
    public class CatalogViewModel : ViewModelBase
    {
        private readonly MainViewModel _mainViewModel;
        private string _searchText = string.Empty;
        private Models.Component _selectedComponent;

        private ObservableCollection<Models.Component> _rawComponents;

        public ICollectionView ComponentsView { get; }
        public ICommand EditComponentCommand { get; }
        public ICommand DeleteComponentCommand { get; }


        public string SearchText
        {
            get => _searchText;
            set
            {
                if (SetProperty(ref _searchText, value))
                    ComponentsView.Refresh();
            }
        }

        public Models.Component SelectedComponent
        {
            get => _selectedComponent;
            set => SetProperty(ref _selectedComponent, value);
        }

        public ICommand AddComponentCommand { get; }

        public CatalogViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            _rawComponents = new System.Collections.ObjectModel.ObservableCollection<Models.Component>();

            LoadDataFromDatabase();

            ComponentsView = CollectionViewSource.GetDefaultView(_rawComponents);
            ComponentsView.Filter = FilterComponents;

            AddComponentCommand = new RelayCommand(p => AddComponent());
            EditComponentCommand = new RelayCommand(p => EditComponent(), c => SelectedComponent != null);
            DeleteComponentCommand = new RelayCommand(p => DeleteComponent(), c => SelectedComponent != null);
        }

        private void LoadDataFromDatabase()
        {
            _rawComponents.Clear();
            using (var db = new AppDbContext())
            {
                if (!db.Components.Any())
                {
                    db.Components.Add(new Models.Component(1, "CPU", "AMD", "Ryzen 5 5600X", 15000, "6 ядер, 12 потоков"));
                    db.Components.Add(new Models.Component(2, "GPU", "NVIDIA", "RTX 4060", 35000, "8 Гб GDDR6"));
                    db.SaveChanges();
                }

                foreach (var component in db.Components.ToList())
                {
                    _rawComponents.Add(component);
                }
            }
        }

        private void AddComponent()
        {
            _mainViewModel.CurrentViewModel = new AddComponentViewModel();
        }

        private void EditComponent()
        {
            if (SelectedComponent == null) return;
            _mainViewModel.CurrentViewModel = new AddComponentViewModel(SelectedComponent);
        }

        private void DeleteComponent()
        {
            if (SelectedComponent == null) return;

            var result = MessageBox.Show(
                "Вы уверены, что хотите безвозвратно удалить " + SelectedComponent.FullName + "?",
                "Подтверждение удаления",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    using (var db = new AppDbContext())
                    {
                        var dbComponent = db.Components.Find(SelectedComponent.Id);
                        if (dbComponent != null)
                        {
                            db.Components.Remove(dbComponent);
                            db.SaveChanges();
                        }
                    }
                    _rawComponents.Remove(SelectedComponent);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private bool FilterComponents(object obj)
        {
            if (!(obj is Models.Component component)) return false;

            if (string.IsNullOrWhiteSpace(SearchText)) return true;

            return component.Model.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                   component.Manufacturer.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private void AddComponentToBuild()
        {
            if (SelectedComponent == null) return;
            System.Windows.MessageBox.Show("Добавлено в сборку: " + SelectedComponent.FullName);
        }
    }
}
