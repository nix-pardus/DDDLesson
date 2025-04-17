using DDDLesson.Common;

namespace DDDLesson.Domain.Workers.GetWorkersList;

public sealed class GetWorkersListQueryResultEntry : IEntry<WorkerId>
{
    public required WorkerId Id { get; init; }
    public required string Name { get; init; }
}
