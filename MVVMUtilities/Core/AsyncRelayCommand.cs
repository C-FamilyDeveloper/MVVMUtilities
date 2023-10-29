using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMUtilities.Core
{
    public class AsyncRelayCommand : ICommand
    {
        private Action execute;
        private Predicate<object> canExecute;
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public AsyncRelayCommand(Action execute, Predicate<object> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        public async void Execute(object parameter)
        {
            await ExecuteAsync();
        }
        private async Task ExecuteAsync()
        {
            await Task.Run(execute);
        }
    }
    
}
