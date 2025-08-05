using DDDLesson.Common;

namespace DDDLesson.WinUI3.ViewModels.Workers.Responses;

public class GetWorkersListResponseEntry
{
    public required WorkerId Id { get; init; }
    public string Name { get; init; }
}
