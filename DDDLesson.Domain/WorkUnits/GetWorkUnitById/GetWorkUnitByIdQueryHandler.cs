using DDDLesson.Infrastructure.Repositories.WorkUnitRepository;
using MediatR;

namespace DDDLesson.Domain.WorkUnits.GetWorkUnitById;

public class GetWorkUnitByIdQueryHandler : IRequestHandler<GetWorkUnitByIdQuery, GetWorkUnitByIdQueryResult>
{
    private readonly IWorkUnitEntityRepository repository;

    public GetWorkUnitByIdQueryHandler(IWorkUnitEntityRepository repository)
    {
        this.repository = repository;
    }

    public async Task<GetWorkUnitByIdQueryResult> Handle(GetWorkUnitByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await repository.GetByIdAsync(request.WorkUnitId, cancellationToken);
        return new GetWorkUnitByIdQueryResult
        {
            Area = response.Area,
            Id = response.Id,
            PackagingType = response.PackagingType,
            WorkDay = response.WorkDay,
            Worker = response.Worker,
        };
    }
}
