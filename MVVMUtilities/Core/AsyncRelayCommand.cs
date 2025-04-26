using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMUtilities.Core
{
    public class AsyncRelayCommand : ICommand
    {
        private Func<Task> execute;
        private Predicate<object> canExecute;
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public AsyncRelayCommand(Func<Task> execute, Predicate<object> canExecute = null)
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
            await execute();
        }
    }
}
