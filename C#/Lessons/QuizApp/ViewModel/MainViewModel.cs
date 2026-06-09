using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QuizApp.Model;

namespace QuizApp.ViewModel
{
    public class MainViewModel: ViewModelBase
    {
        public ICommand OpenQuizSelectionCommand { get; }
        public ICommand OpenCreateQuizCommand { get; }

        public MainViewModel()
        {
            OpenQuizSelectionCommand = new RelayCommand(_ => OpenQuizSelection());
            OpenCreateQuizCommand = new RelayCommand(_ => OpenCreateQuiz());
        }

        private void OpenQuizSelection()
        {
            QuizSelectionWindow window = new QuizSelectionWindow();
            window.Show();
        }

        private void OpenCreateQuiz()
        {
            CreateQuizWindow window = new CreateQuizWindow();
            window.Show();
        }
    }
}
