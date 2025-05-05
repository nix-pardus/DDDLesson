using DDDLesson.Common;
using MediatR;

namespace DDDLesson.Domain.PackagingTypes.CreatePackagingType;

public class CreatePackagingTypeCommand : IRequest<PackagingTypeId>
{
    public required string Name { get; init; }
    public required decimal PricePerSquareMeter { get; init; }
    public required decimal PricePerSquareMeterOnWeeken { get; init; }
}
