using MediatR;

namespace DDDLesson.Domain.WorkDays.GetWorkDaysOfMonth;

public class GetWorkDaysOfMonthListQuery : IRequest<GetWorkDaysOfMonthListQueryResult>
{
    public required DateTime Month { get; init; }
}
