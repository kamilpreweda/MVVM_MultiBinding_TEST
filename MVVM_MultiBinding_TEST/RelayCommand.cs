using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM_MultiBinding_TEST
{
    public class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            if (_canExecuteMethod != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Execute(object? parameter)
        {
            _executeMethod(parameter);
        }

        Action<object> _executeMethod;
        Func<object, bool> _canExecuteMethod;

        public RelayCommand(Action<object> executeMethod, Func<object, bool> canExecuteMethod)
        {
            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
        }
    }
}
