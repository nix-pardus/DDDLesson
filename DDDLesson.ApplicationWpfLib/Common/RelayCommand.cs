using System.Windows.Input;

namespace DDDLesson.ApplicationWpfLib.Common;

public class RelayCommand : ICommand
{
    protected readonly Func<Task> _execute;
    protected readonly Func<bool> _canExecute;

    public RelayCommand(Func<Task> execute, Func<bool> canExecute = null!)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public bool CanExecute(object? parameter) => _canExecute == null || _canExecute();

    public async void Execute(object? parameter) => await _execute();
}
