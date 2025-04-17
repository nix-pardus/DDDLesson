using DDDLesson.Common;

namespace DDDLesson.ApplicationWpfLib.ViewModels.Workers.GetWorkersList;

public class GetWorkersListResponseEntry
{
    public required WorkerId Id { get; init; }
    public required string Name { get; init; }
}
