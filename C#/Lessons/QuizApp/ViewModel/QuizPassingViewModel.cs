using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using QuizApp.Model;

namespace QuizApp.ViewModel
{
    internal class QuizPassingViewModel: ViewModelBase
    {
        public Quiz CurrentQuiz { get; }
        private int currentQuestionIndex = 0;

        private Question currentQuestion;
        public Question CurrrrentQuestion
        {
            get => currentQuestion;
            set
            {
                currentQuestion = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand NextQuestionCommand { get; }

        public QuizPassingViewModel()
        { }

        public QuizPassingViewModel(Quiz quiz)
        {
            CurrentQuiz = quiz;
            if(quiz.Questions.Count > 0)
                CurrrrentQuestion = quiz.Questions[0];
            NextQuestionCommand = new RelayCommand(_ => NextQuestion());
        }

        private void NextQuestion()
        {
            currentQuestionIndex++;

            if (currentQuestionIndex < CurrentQuiz.Questions.Count)
            {
                CurrrrentQuestion = CurrentQuiz.Questions[currentQuestionIndex];
            }
            else
            {
                MessageBox.Show("Викторина завершена");
            }
        }
    }
}
