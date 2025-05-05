using DDDLesson.Common;
using MediatR;

namespace DDDLesson.Domain.WorkDays.CreateWorkDays;

public class CreateWorkDaysCommand : IRequest<IReadOnlyCollection<WorkDayId>>
{
    //public required IReadOnlyCollection<>
}
