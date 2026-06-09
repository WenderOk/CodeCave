using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using QuizApp.ViewModel;

namespace QuizApp
{
    /// <summary>
    /// Логика взаимодействия для CreateQuizWindow.xaml
    /// </summary>
    public partial class CreateQuizWindow : Window
    {
        public CreateQuizViewModel model {  get; } = new CreateQuizViewModel();
        public CreateQuizWindow()
        {
            InitializeComponent();
            DataContext = model;
        }
    }
}
