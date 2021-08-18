using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

public class RelayCommand : ICommand
{
    readonly Action<object> _execute;

    public event EventHandler CanExecuteChanged;
    public RelayCommand(Action<object> execute)
    {
        if (execute == null)
        {
            throw new ArgumentNullException("execute");
        }

        _execute = execute;
    }

    public bool CanExecute(object parameter)
    {
        return true;
    }

    public void Execute(object parameter)
    {
        _execute(parameter);
    }
}
