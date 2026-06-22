using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Wpf_observation_1.Model;
using Wpf_observation_1.View;

namespace Wpf_observation_1.ViewModel
{
	public class MainVM
	{
		public ICommand OpenWorkBDCommand { get; }
		public ICommand OpenCreateCommand { get; }


		public MainVM()
		{
			OpenWorkBDCommand = new RelayCommand(_ => OpenWorkBD());

			OpenCreateCommand = new RelayCommand(_ => OpenCreateObservation());
		}


		private void OpenWorkBD()
		{
			WorkBDWindow window = new WorkBDWindow();	
			window.Show();
		}

		private void OpenCreateObservation()
		{
			CreateObservationWindow1 window = new CreateObservationWindow1();
			window.Show();
		}

	}
}
