using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Wpf_observation_1.Model
{
	public class RelayCommand : ICommand
	{
		private readonly Action<object> execute;
		private readonly Predicate<object> canExecute;

		public RelayCommand(Action<object> execute,
							Predicate<object> canExecute = null)
		{
			this.execute = execute;
			this.canExecute = canExecute;
		}

		public bool CanExecute(object parameter)
		{
			return canExecute == null || canExecute(parameter);
		}

		public void Execute(object parameter)
		{
			execute(parameter);
		}

		public event EventHandler CanExecuteChanged
		{
			add => CommandManager.RequerySuggested += value;
			remove => CommandManager.RequerySuggested -= value;
		}
	}
}
