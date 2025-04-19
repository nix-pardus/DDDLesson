using CommunityToolkit.Mvvm.ComponentModel;
using DDDLesson.ApplicationWinUI3.Features.Workers.CreateWorker;
using DDDLesson.ApplicationWinUI3.Features.Workers.DeleteWorker;
using DDDLesson.ApplicationWinUI3.Features.Workers.GetWorkersList;

namespace DDDLesson.ApplicationWinUI3;

public partial class MainViewModel : ObservableValidator
{
    public CreateWorkerViewModel CreateWorker { get; }
    public GetWorkerListViewModel GetWorkerList { get; }
    public DeleteWorkerViewModel DeleteWorker { get; }

    public MainViewModel
    (
        CreateWorkerViewModel createWorker,
        GetWorkerListViewModel getWorkerList,
        DeleteWorkerViewModel deleteWorker
    )
    {
        CreateWorker = createWorker;
        GetWorkerList = getWorkerList;
        DeleteWorker = deleteWorker;
    }
}
