using DDDLesson.Common;
using MediatR;

namespace DDDLesson.Domain.WorkDays.CreateWorkDay;

public class CreateWorkDayCommand : IRequest<WorkDayId>
{
    public required DateTime Date { get; init; }

    public required bool IsWeekend { get; init; }
}
