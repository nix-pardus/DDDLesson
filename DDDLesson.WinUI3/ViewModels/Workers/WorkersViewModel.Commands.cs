using CommunityToolkit.Mvvm.Input;
using DDDLesson.Domain.Workers.CreateWorker;
using DDDLesson.Domain.Workers.DeleteWorker;
using DDDLesson.Domain.Workers.EditWorker;
using DDDLesson.Domain.Workers.GetWorkersList;
using DDDLesson.WinUI3.ViewModels.Workers.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace DDDLesson.WinUI3.ViewModels.Workers;

//Commands

public partial class WorkersViewModel
{
    [RelayCommand]
    public async Task GetWorkersAsync()
    {
        var response = await mediator.Send(new GetWorkersListQuery());
        WorkersList = mapper.Map<GetWorkersListResponse>(response).Entries;
    }

    [RelayCommand(CanExecute = nameof(CanCreateWorker))]
    public async Task SaveWorkerAsync(CancellationToken cancellationToken)
    {
        if(!isEditMode)
        {
            await mediator.Send(new CreateWorkerCommand()
            {
                Name = WorkerName,
                IsInOurShift = IsInOurShift
            }, cancellationToken);
        }
        else
        {
            await mediator.Send(new EditWorkerCommand()
            {
                Id = SelectedWorker.Id,
                WorkerName = WorkerName
            }, cancellationToken);
            isEditMode = false;
            IsPaneOpen = false;
        }
        WorkerName = string.Empty;
    }

    [RelayCommand(CanExecute = nameof(CanDeleteOrEditWorker))]
    public void EditWorker()
    {
        isEditMode = true;
        IsPaneOpen = true;
        WorkerName = SelectedWorker.Name;
        IsInOurShift = SelectedWorker.IsInOurShift;
    }

    [RelayCommand(CanExecute = nameof(CanDeleteOrEditWorker))]
    public async Task DeleteWorkerAsync(CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteWorkerCommand()
        {
            WorkerId = SelectedWorker.Id
        }, cancellationToken);
    }

    [RelayCommand]
    private void GoBack()
    {
        navigationService.GoBack();
    }

    [RelayCommand]
    private void SplitViewPaneOpen()
    {
        IsPaneOpen = !IsPaneOpen;
    }

    [RelayCommand]
    private void SplitViewPaneClose()
    {
        IsPaneOpen = false;
        WorkerName = string.Empty;
    }
}
