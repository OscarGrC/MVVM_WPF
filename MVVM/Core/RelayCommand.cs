using System.Windows.Input;
using System.Windows.Media.Animation;

namespace MVVM.Core;
internal class RelayCommand : ICommand
{
    private Action<object> _execute;
    private Func<object,bool> _canExecute;

    //evento (se puede implomentar con add y remove)
    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    //public constructor
    public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
    { 
        //asociamos para no tener que escribir esto por cada comando 
        _execute = execute;
        _canExecute = canExecute;
    }

    public bool CanExecute(object? parameter) =>
        _canExecute == null || _canExecute(parameter);
    

    public void Execute(object? parameter)
    {
       _execute?.Invoke(parameter);
    }
}
