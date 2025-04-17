namespace DDDLesson.Domain.Workers.GetWorkersList;

public class GetWorkersListQueryResult
{
    public required IReadOnlyCollection<GetWorkersListQueryResultEntry> Entries { get; init; }
}
