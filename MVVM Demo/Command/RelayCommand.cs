using System;
using System.Windows.Input;

namespace MVVM_Demo.Command
{
    public class RelayCommand : ICommand
    {
        Action<object> _execute;
        Func<object, bool> _canExecute;
        bool _isExecuted;

        public RelayCommand(Action<object> _execute, Func<object,bool>_canExecute, bool _isExecuted)
        {
            this._execute = _execute;
            this._canExecute = _canExecute;
            this._isExecuted = _isExecuted;
        }

        public bool CanExecute(object parameter)
        {
            if(_canExecute == null) { return true; }
            else { return _canExecute(parameter); }
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested+=value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
            
    }
}
