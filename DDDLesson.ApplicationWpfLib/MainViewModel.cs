using DDDLesson.ApplicationWpfLib.Common;
using DDDLesson.ApplicationWpfLib.Features.Workers.CreateWorker;
using DDDLesson.ApplicationWpfLib.Features.Workers.GetWorkersList;

namespace DDDLesson.ApplicationWpfLib;

public class MainViewModel : ViewModelBase
{
    public CreateWorkerViewModel CreateWorker { get; }
    public GetWorkersListViewModel GetWorkersList { get; }

    public MainViewModel(CreateWorkerViewModel createWorker, GetWorkersListViewModel getWorkersList)
    {
        CreateWorker = createWorker;
        GetWorkersList = getWorkersList;

        CreateWorker.WorkerCreated += async () =>
        {
            await GetWorkersList.LoadWorkersAsync();
        };
    }
}
