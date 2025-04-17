using System.Collections.ObjectModel;

namespace DDDLesson.ApplicationWpfLib.ViewModels.Workers.GetWorkersList;

public class GetWorkersListResponse
{
    public required ObservableCollection<GetWorkersListResponseEntry> Entries { get; init; }
}
