using DDDLesson.Common;
using MediatR;

namespace DDDLesson.Domain.PackagingTypes.EditPackagingType;

public class EditPackagingTypeCommand : IRequest<PackagingTypeId>
{
    public required PackagingTypeId Id { get; init; }
    public required string Name { get; init; }
    public required decimal PricePerSquareMeter { get; init; }
    public required decimal PricePerSquareMeterOnWeeken { get; init; }
}
