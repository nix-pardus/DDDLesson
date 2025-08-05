using DDDLesson.Common;
using DDDLesson.Infrastructure.Persistence.Entities;

namespace DDDLesson.Domain.WorkDays.GetWorkDaysOfMonth;

public class GetWorkDaysOfMonthListQueryResultEntry
{
    public required WorkDayId Id { get; init; }
    public required DateTime Date { get; init; }
    public required IReadOnlyCollection<WorkUnitEntity>? WorkUnits { get; init; }
    public required bool IsWeekend { get; init; }
}
