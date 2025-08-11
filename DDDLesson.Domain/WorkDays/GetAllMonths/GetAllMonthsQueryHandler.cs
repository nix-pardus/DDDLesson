using DDDLesson.Infrastructure.Persistence.Entities;
using DDDLesson.Infrastructure.Repositories.WorkDayRepository;
using MediatR;

namespace DDDLesson.Domain.WorkDays.GetAllMonths;

public class GetAllMonthsQueryHandler : IRequestHandler<GetAllMonthsQuery, GetAllMonthsQueryResult>
{
    private readonly IWorkDayEntityRepository repository;

    public GetAllMonthsQueryHandler(IWorkDayEntityRepository repository)
    {
        this.repository = repository;
    }

    public async Task<GetAllMonthsQueryResult> Handle(GetAllMonthsQuery request, CancellationToken cancellationToken)
    {
        //var response = await repository.FilterAsync(
        //    buildQuery: q => q
        //        .GroupBy(e => new { e.Date.Year, e.Date.Month })
        //        .Select(g => g.First()),
        //    orderBy: q => q
        //        .OrderBy(e => e.Date.Year)
        //        .ThenBy(e => e.Date.Month),
        //    cancellationToken: cancellationToken);
        //var months = response.Select(month => new GetAllMonthsQueryResultEntry
        //{
        //    Date = month.Date
        //}).ToArray();
        //return new GetAllMonthsQueryResult
        //{
        //    Entries = months
        //};

        var response = await repository.FilterAsync(
            buildQuery: q => q
                .Select(e => new WorkDayEntity
                {
                    Date = e.Date,
                    IsWeekend = e.IsWeekend,
                    Id = e.Id,
                }),
            orderBy: q => q
                .OrderBy(e => e.Date.Year)
                .ThenBy(e => e.Date.Month),
            cancellationToken: cancellationToken);

        var months = response.Select(item => new GetAllMonthsQueryResultEntry
        {
            Date = new DateTime(item.Date.Year, item.Date.Month, 1)
        })
            .GroupBy(e => e.Date)
            .Select(e => new GetAllMonthsQueryResultEntry
            {
                Date = e.Key
            })
            .ToArray();
        return new GetAllMonthsQueryResult
        {
            Entries = months
        };
    }
}
