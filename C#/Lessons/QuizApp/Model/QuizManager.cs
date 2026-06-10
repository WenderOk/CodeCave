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
        public Quiz currentQuiz { get; set; } = new Quiz();

        public QuizManager()
        { currentQuiz = new Quiz(); }
        


        // метод загрузки из файла
        public Quiz LoadQuiz(string path)
        {
            if (!File.Exists(path))
                return null;

            XmlSerializer serializer =
                new XmlSerializer(typeof(Quiz));

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                return (Quiz)serializer.Deserialize(fs);
            }
        }

        public void SaveQuiz(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Quiz));
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                serializer.Serialize(fs, currentQuiz);
            }
        }

    }
}
