using System;
using System.Windows;
using QuizApp.Model;
using QuizApp.ViewModel;

namespace QuizApp
{
    /// <summary>
    /// Логика взаимодействия для QuizPassingWindow.xaml
    /// </summary>
    public partial class QuizPassingWindow : Window
    {
        public QuizPassingWindow(Quiz quiz)
        {
            InitializeComponent();
            DataContext = new QuizPassingViewModel(quiz);
        }
    }
}
