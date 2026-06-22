using PcLibraryApp.Infrastructure;
using PcLibraryApp.Models;
using PcLibraryApp.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Data.Entity;
using System.Windows;
using System.Windows.Input;

namespace PcLibraryApp.ViewModels
{
    public class BuildsViewModel : ViewModelBase
    {
        private readonly MainViewModel _mainViewModel;
        private PcBuild _selectedBuild;

        public ObservableCollection<PcBuild> SavedBuilds { get; set; }

        public PcBuild SelectedBuild
        {
            get => _selectedBuild;
            set => SetProperty(ref _selectedBuild, value);
        }

        public ICommand DeleteBuildCommand { get; }
        public ICommand EditBuildCommand { get; }

        public BuildsViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            SavedBuilds = new ObservableCollection<PcBuild>();
            LoadBuildsFromDatabase();

            DeleteBuildCommand = new RelayCommand(p => DeleteBuild(), c => SelectedBuild != null);
            EditBuildCommand = new RelayCommand(p => EditBuild(), c => SelectedBuild != null);
        }

        private void EditBuild()
        {
            if (SelectedBuild == null) return;
            // Открываем конструктор в режиме редактирования, передавая выбранную сборку
            _mainViewModel.CurrentViewModel = new ConstructorViewModel(SelectedBuild);
        }

        private void LoadBuildsFromDatabase()
        {
            SavedBuilds.Clear();
            try
            {
                using (var db = new AppDbContext())
                {
                    var dbBuilds = db.Builds.Include(b => b.Components).ToList();

                    foreach (var build in dbBuilds)
                    {
                        build.RefreshPrice();
                        SavedBuilds.Add(build);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке сборок: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteBuild()
        {
            if (SelectedBuild == null) return;

            var result = MessageBox.Show(
                $"Вы уверены, что хотите удалить сборку '{SelectedBuild.Name}'? Привязанные детали снова станут свободны для новых сборок.",
                "Подтверждение удаления",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    using (var db = new AppDbContext())
                    {
                        var dbBuild = db.Builds.Include(b => b.Components).FirstOrDefault(b => b.Id == SelectedBuild.Id);
                        if (dbBuild != null)
                        {
                            db.Builds.Remove(dbBuild);
                            db.SaveChanges();
                        }
                    }

                    SavedBuilds.Remove(SelectedBuild);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении сборки: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
