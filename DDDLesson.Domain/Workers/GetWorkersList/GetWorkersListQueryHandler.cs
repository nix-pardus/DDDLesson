using DDDLesson.Infrastructure.Repositories.WorkerRepository;
using MediatR;

namespace DDDLesson.Domain.Workers.GetWorkersList;

public class GetWorkersListQueryHandler : IRequestHandler<GetWorkersListQuery, GetWorkersListQueryResult>
{
    private readonly IWorkerEntityRepository repository;

    public GetWorkersListQueryHandler(IWorkerEntityRepository repository)
    {
        this.repository = repository;
    }

    public async Task<GetWorkersListQueryResult> Handle(GetWorkersListQuery request, CancellationToken cancellationToken)
    {
        var entries = await repository.GetAllAsync(cancellationToken);
        var result = entries
            .Select(entity => new GetWorkersListQueryResultEntry
            {
                Id = entity.Id,
                Name = entity.Name,
                IsInOurShift = entity.IsInOurShift
            })
            .ToArray();
        return new GetWorkersListQueryResult
        {
            Entries = result
        };
    }
}
