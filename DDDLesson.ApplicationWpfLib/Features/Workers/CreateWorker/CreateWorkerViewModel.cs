using DDDLesson.ApplicationWpfLib.Common;
using DDDLesson.Domain.Workers.CreateWorker;
using MediatR;
using System.Windows.Input;

namespace DDDLesson.ApplicationWpfLib.Features.Workers.CreateWorker;

public class CreateWorkerViewModel : ViewModelBase
{
    private readonly IMediator mediator;
    private string name = string.Empty;

    public CreateWorkerViewModel(IMediator mediator)
    {
        this.mediator = mediator;
        CreateWorkerCommand = new RelayCommand(async () => await CreateWorkerAsync());
    }

    public string Name
    {
        get => name;
        set
        {
            name = value;
            OnPropertyChanged();
        }
    }

    public ICommand CreateWorkerCommand { get; }

    public event Action? WorkerCreated;

    public async Task CreateWorkerAsync()
    {
        if (!string.IsNullOrWhiteSpace(Name))
        {
            await mediator.Send(new CreateWorkerCommand { Name = Name });
            Name = string.Empty;
            WorkerCreated?.Invoke();
        }
    }
}
