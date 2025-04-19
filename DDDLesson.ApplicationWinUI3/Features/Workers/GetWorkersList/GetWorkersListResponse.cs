using System.Collections.ObjectModel;

namespace DDDLesson.ApplicationWinUI3.Features.Workers.GetWorkersList;

public class GetWorkersListResponse
{
    public required ObservableCollection<GetWorkersListResponseEntry> Entries { get; init; }
}
