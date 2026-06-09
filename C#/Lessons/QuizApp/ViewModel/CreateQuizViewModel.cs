using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Win32;
using QuizApp.Model;

namespace QuizApp.ViewModel
{
    public class CreateQuizViewModel: ViewModelBase
    {
        private ObservableCollection<Question> Questions { get; set; }
        public string QuizName { get; set; }
        private Question currentQuestion;
        private QuizManager manager;

        public Question CurrentQuestion
        {
            get => currentQuestion;
            set
            {
                currentQuestion = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddQuestionCommand { get; }
        public ICommand RemoveQuestionCommand { get; }
        public ICommand SaveQuestionCommand { get; }
        public ICommand AddAnswerCommand { get; }
        public ICommand RemoveAnswerCommand { get; }
        public ICommand FinishQuizCommand { get; }

        public CreateQuizViewModel()
        {
            Questions = new ObservableCollection<Question>();
            CurrentQuestion = new Question();
            CurrentQuestion.Id = 1;
            manager = new QuizManager();

            CurrentQuestion.Answers.Add(new Answer("", false));
            //AddQuestionCommand = new RelayCommand(_ => AddAnswer());
            SaveQuestionCommand = new RelayCommand(_ => SaveCurrentQuestion());
            AddAnswerCommand = new RelayCommand(_ => AddAnswer());
            FinishQuizCommand = new RelayCommand(_ => FinishQuiz());
        }
        
        private void AddAnswer()
        {
            CurrentQuestion.Answers.Add(new Answer("", false));
        }

        private void SaveCurrentQuestion()
        {
            Questions.Add(currentQuestion);

            currentQuestion = new Question
            {
                Id = Questions.Count + 1
            };
            CurrentQuestion.Answers.Add(new Answer("", false));

            OnPropertyChanged(nameof(CurrentQuestion));
        }

        private void FinishQuiz()
        {
            if(!Questions.Contains(currentQuestion))
                Questions.Add(currentQuestion);
            manager.currentQuiz.Name = QuizName;
            manager.currentQuiz.Questions = Questions;
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.Filter = "XML files (*.xml)|*.xml";
            dialog.DefaultExt = ".xml";
            dialog.FileName = QuizName;

            if(dialog.ShowDialog() == true)
                manager.SaveQuiz(dialog.FileName);
        }
    }
}
