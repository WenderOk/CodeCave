using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using QuizApp.Model;

namespace QuizApp.ViewModel
{
    public class SelectQuizViewModel : ViewModelBase
    {
        public QuizManager manager = new QuizManager();

        public ObservableCollection<QuizInfo> AvailableQuizzes { get; } = new ObservableCollection<QuizInfo>();
        private QuizInfo selectedQuiz;

        public QuizInfo SelectedQuiz
        {
            get => selectedQuiz;
            set
            {
                selectedQuiz = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand StartQuizCommand { get; }

        public SelectQuizViewModel()
        {
            StartQuizCommand = new RelayCommand(_ => StartQuiz(), _ => SelectedQuiz != null);
            LoadQuizList();
        }


        private void LoadQuizList()
        {
            string folder = @"Quizzes";

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            foreach (string file in Directory.GetFiles(folder, "*.xml"))
            {
                Quiz quiz = manager.LoadQuiz(file);

                AvailableQuizzes.Add(
                    new QuizInfo
                    {
                        Name = quiz.Name,
                        FilePath = file
                    });
            }
        }

        public void StartQuiz()
        {
            if (SelectedQuiz == null)
                return;
            Quiz quiz = manager.LoadQuiz(SelectedQuiz.FilePath);
            QuizPassingWindow window = new QuizPassingWindow(quiz);
            window.Show();
        }
    }
}
