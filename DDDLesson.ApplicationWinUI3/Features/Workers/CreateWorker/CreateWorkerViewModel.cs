using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DDDLesson.ApplicationWinUI3.Features.Workers.GetWorkersList;
using DDDLesson.Domain.Workers.CreateWorker;
using DDDLesson.Infrastructure.Persistence;
using DDDLesson.Infrastructure.Repositories.WorkerRepository;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace DDDLesson.ApplicationWinUI3.Features.Workers.CreateWorker;

public partial class CreateWorkerViewModel : ObservableValidator
{
    private readonly IMediator mediator;
    private string name = string.Empty;

    [Required(ErrorMessage = "Имя обязательно")]
    [MinLength(2, ErrorMessage = "Имя не может быть короче 2 символов")]
    public string Name
    {
        get => name;
        set
        {
            SetProperty(ref name, value, true);
            CreateWorkerCommand.NotifyCanExecuteChanged();
        }
    }

    public bool CanCreateWorker => !string.IsNullOrWhiteSpace(Name) && !HasErrors;

    public CreateWorkerViewModel(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [RelayCommand(IncludeCancelCommand = true, CanExecute = nameof(CanCreateWorker))]
    public async Task CreateWorkerAsync(CancellationToken cancellationToken)
    {
        if (CanCreateWorker)
        {
            await mediator.Send(new CreateWorkerCommand() { Name = Name }, cancellationToken);
            Name = string.Empty;
        }
    }
}
