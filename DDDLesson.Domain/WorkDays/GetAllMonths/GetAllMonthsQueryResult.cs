namespace DDDLesson.Domain.WorkDays.GetAllMonths;

public class GetAllMonthsQueryResult
{
    public required IReadOnlyCollection<GetAllMonthsQueryResultEntry> Entries { get; init; }
}
