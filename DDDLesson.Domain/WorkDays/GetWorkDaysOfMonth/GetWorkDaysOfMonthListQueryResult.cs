namespace DDDLesson.Domain.WorkDays.GetWorkDaysOfMonth;

public class GetWorkDaysOfMonthListQueryResult
{
    public required IReadOnlyCollection<GetWorkDaysOfMonthListQueryResultEntry> Entries { get; init; }
}
