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
using Wpf_observation_1.ViewModel;

namespace Wpf_observation_1.View
{
	/// <summary>
	/// Логика взаимодействия для CreateObservationWindow1.xaml
	/// </summary>
	public partial class CreateObservationWindow1 : Window
	{
		
		public CreateObservationWindow1()
		{			
			InitializeComponent();			
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
        }
    }
}
