using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace MVVMUtilities.Core
{
    public class GUIRelayCommand : ICommand
    {
        private Action execute;
        private Predicate<object> canExecute;
        private Dispatcher dispatcher;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public GUIRelayCommand (Action execute, Dispatcher dispatcher = null, Predicate<object> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
            this.dispatcher = dispatcher;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        public  void Execute(object parameter)
        {            
            if (dispatcher is not null)
            {
                dispatcher.Invoke(execute);
            }
            else
            {
                Application.Current.Dispatcher.Invoke(execute);
            }

        }
    }
}
