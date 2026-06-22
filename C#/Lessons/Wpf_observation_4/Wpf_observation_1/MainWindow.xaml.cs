using Microsoft.Data.Sqlite;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf_observation_1.Model;
using Wpf_observation_1.ViewModel;
using Microsoft.Data.Sqlite;
using System.IO;

namespace Wpf_observation_1
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		
		public MainWindow()
		{
			
			InitializeComponent();
			
		}

		/*private void Button_Click(object sender, RoutedEventArgs e)
		{
			//string dbPath = Path.GetFullPath("SqlObservation.db");

			//MessageBox.Show(dbPath);
			using (SqliteConnection connection = DataBase.GetConnection())
			{
				connection.Open();
				MessageBox.Show("Подключение успешно!");
			}
			
		}*/
    }
}
