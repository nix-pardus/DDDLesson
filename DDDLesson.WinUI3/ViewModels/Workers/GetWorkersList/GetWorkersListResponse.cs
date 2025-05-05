using System.Collections.ObjectModel;

namespace DDDLesson.WinUI3.ViewModels.Workers.GetWorkersList;

public class GetWorkersListResponse
{
    public required ObservableCollection<GetWorkersListResponseEntry> Entries { get; init; }
}
