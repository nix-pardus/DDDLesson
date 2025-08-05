using DDDLesson.Infrastructure.Repositories.WorkDayRepository;
using MediatR;

namespace DDDLesson.Domain.WorkDays.GetWorkDaysOfMonth;

public class GetWorkDaysOfMonthListQueryHandler : IRequestHandler<GetWorkDaysOfMonthListQuery, GetWorkDaysOfMonthListQueryResult>
{
    private readonly IWorkDayEntityRepository repository;

    public GetWorkDaysOfMonthListQueryHandler(IWorkDayEntityRepository repository)
    {
        this.repository = repository;
    }

    public async Task<GetWorkDaysOfMonthListQueryResult> Handle(GetWorkDaysOfMonthListQuery request, CancellationToken cancellationToken)
    {
        var response = await repository.FilterAsync(q => q.Where(q => q.Date.Month == request.Month.Month), q => q.OrderBy(q => q.Date), cancellationToken);
        var entries = response.Select(entry => new GetWorkDaysOfMonthListQueryResultEntry
        {
            Id = entry.Id,
            Date = entry.Date,
            IsWeekend = entry.IsWeekend,
            WorkUnits = entry.WorkUnits,
        }).ToArray();

        return new GetWorkDaysOfMonthListQueryResult
        {
            Entries = entries,
        };
    }
}
