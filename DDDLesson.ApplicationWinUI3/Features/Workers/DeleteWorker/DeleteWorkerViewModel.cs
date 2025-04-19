using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DDDLesson.ApplicationWinUI3.Features.Workers.GetWorkersList;
using DDDLesson.Domain.Workers.DeleteWorker;
using MediatR;
using System.Threading.Tasks;

namespace DDDLesson.ApplicationWinUI3.Features.Workers.DeleteWorker;

public partial class DeleteWorkerViewModel : ObservableValidator
{
    private readonly IMediator mediator;
    private GetWorkersListResponseEntry selectedWorker;

    public DeleteWorkerViewModel(IMediator mediator)
    {
        this.mediator = mediator;
    }

    public GetWorkersListResponseEntry SelectedWorker
    {
        get => selectedWorker;
        set => SetProperty(ref selectedWorker, value);
    }

    [RelayCommand]
    private async Task DeleteWorkerAsync()
    {
        if(SelectedWorker != null)
        {
            await mediator.Send(new DeleteWorkerCommand { WorkerId = SelectedWorker.Id });
        }
    }
}
