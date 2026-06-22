using PcLibraryApp.Infrastructure;
using PcLibraryApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PcLibraryApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }

        public ICommand OpenCatalogCommand { get; }
        public ICommand OpenConstructorCommand { get; }
        public ICommand OpenAddComponentCommand { get; }
        public ICommand OpenBuildsCommand { get; }

        public MainViewModel()
        {
            CurrentViewModel = new CatalogViewModel(this);

            OpenCatalogCommand = new RelayCommand(p => CurrentViewModel = new CatalogViewModel(this));
            OpenConstructorCommand = new RelayCommand(p => CurrentViewModel = new ConstructorViewModel());
            OpenAddComponentCommand = new RelayCommand(p => CurrentViewModel = new AddComponentViewModel());
            OpenBuildsCommand = new RelayCommand(p => CurrentViewModel = new BuildsViewModel(this));
        }
    }
}
