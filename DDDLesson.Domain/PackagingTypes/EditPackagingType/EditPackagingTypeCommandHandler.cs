using DDDLesson.Common;
using DDDLesson.Infrastructure.Repositories.PackagingTypeRepository;
using MediatR;

namespace DDDLesson.Domain.PackagingTypes.EditPackagingType;

public class EditPackagingTypeCommandHandler : IRequestHandler<EditPackagingTypeCommand, PackagingTypeId>
{
    private readonly IPackagingTypeEntityRepository repository;

    public EditPackagingTypeCommandHandler(IPackagingTypeEntityRepository repository)
    {
        this.repository = repository;
    }

    public async Task<PackagingTypeId> Handle(EditPackagingTypeCommand request, CancellationToken cancellationToken)
    {
        var isUpdated = await repository.UpdateAsync(request.Id, packagingTypeEntity =>
        {
            packagingTypeEntity.Name = request.Name;
            packagingTypeEntity.PricePerSquareMeter = request.PricePerSquareMeter;
            packagingTypeEntity.PricePerSquareMeterOnWeekend = request.PricePerSquareMeterOnWeeken;
        });

        if (isUpdated)
        {
            return request.Id;
        }
        throw new Exception("Error update packaging type");
    }
}
