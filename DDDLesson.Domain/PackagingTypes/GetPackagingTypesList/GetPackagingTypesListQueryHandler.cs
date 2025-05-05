using DDDLesson.Infrastructure.Repositories.PackagingTypeRepository;
using MediatR;

namespace DDDLesson.Domain.PackagingTypes.GetPackagingTypesList;

public class GetPackagingTypesListQueryHandler : IRequestHandler<GetPackagingTypesListQuery, GetPackagingTypesListQueryResult>
{
    private readonly IPackagingTypeEntityRepository repository;

    public GetPackagingTypesListQueryHandler(IPackagingTypeEntityRepository repository)
    {
        this.repository = repository;
    }

    public async Task<GetPackagingTypesListQueryResult> Handle(GetPackagingTypesListQuery request, CancellationToken cancellationToken)
    {
        var response = await repository.GetAllAsync(cancellationToken);
        var entries = response.Select(entry => new GetPackagingTypesListQueryResultEntry
        {
            Id = entry.Id,
            Name = entry.Name,
            PricePerSquareMeter = entry.PricePerSquareMeter,
            PricePerSquareMeterOnWeekend = entry.PricePerSquareMeterOnWeekend
        }).ToArray();

        return new GetPackagingTypesListQueryResult
        {
            Entries = entries
        };
    }
}
