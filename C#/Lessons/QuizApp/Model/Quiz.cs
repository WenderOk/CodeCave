using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model
{
    public class Quiz
    {
        public string Name { get; set; }
        public ObservableCollection<Question> Questions { get; set; }

        public Quiz() 
        { Questions = new ObservableCollection<Question>(); }

    }

    public class Answer
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        public Answer() { }
        public Answer(string text, bool isCorrect) 
        {
            Text = text;
            IsCorrect = isCorrect;
        }
    }

    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public ObservableCollection<Answer> Answers { get; set; }

        public Question() 
        {
            Answers = new ObservableCollection<Answer>();
        }
        public Question(int id, string text)
        {
            Id = id;
            Text = text;
            Answers = new ObservableCollection<Answer>();
        }
    }
}
