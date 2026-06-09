using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace QuizApp.Model
{
    public class QuizManager
    {
        public ObservableCollection<Question> questions;
        public Quiz currentQuiz { get; set; } = new Quiz();

        //public QuizManager() 
        //{ currentQuiz = new Quiz(); }
        public void SaveQuiz(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Quiz));
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                serializer.Serialize(fs, currentQuiz);
            }
        }

        // метод загрузки из файла
        public void LoadFomFile(string path)
        {
            if (!File.Exists(path))
                return;

            XmlSerializer serializer =
                new XmlSerializer(typeof(ObservableCollection<Question>));

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                questions = (ObservableCollection<Question>)serializer.Deserialize(fs);
            }
        }

    }
}
