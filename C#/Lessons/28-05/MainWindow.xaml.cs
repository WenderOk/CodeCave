using System.Data;
using System.Windows;
using System.Windows.Controls;


namespace _28_05
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            textLabel.Text = string.Empty;
            foreach (UIElement el in MainRoot.Children)
            {
                if (el is Button)
                    ((Button)el).Click += Button_Click;
                
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content;
            if (str == "AC")
                textLabel.Text = "";
            else if(str == "=")
            {
                string value = new DataTable().Compute(textLabel.Text, null).ToString();
                textLabel.Text = value;
            }
            else
               textLabel.Text += str;
        }
    }
}
