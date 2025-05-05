using DDDLesson.Common;
using DDDLesson.Infrastructure.Persistence.Entities;
using DDDLesson.Infrastructure.Repositories.PackagingTypeRepository;
using MediatR;

namespace DDDLesson.Domain.PackagingTypes.CreatePackagingType;

public class CreatePackagingTypeCommandHandler : IRequestHandler<CreatePackagingTypeCommand, PackagingTypeId>
{
    private readonly IPackagingTypeEntityRepository repository;

    public CreatePackagingTypeCommandHandler(IPackagingTypeEntityRepository repository)
    {
        this.repository = repository;
    }

    public async Task<PackagingTypeId> Handle(CreatePackagingTypeCommand request, CancellationToken cancellationToken)
    {
        var packagingType = await repository.AddAsync(new PackagingTypeEntity
        {
            Id = PackagingTypeId.New(),
            Name = request.Name,
            PricePerSquareMeter = request.PricePerSquareMeter,
            PricePerSquareMeterOnWeekend = request.PricePerSquareMeterOnWeeken
        });
        return packagingType.Entity.Id;
    }
}
