using DDDLesson.Common;

namespace DDDLesson.Domain.PackagingTypes.GetPackagingTypesList;

public sealed class GetPackagingTypesListQueryResultEntry : IEntry<PackagingTypeId>
{
    public required PackagingTypeId Id { get; init; }
    public required string Name { get; init; }
    public required decimal PricePerSquareMeter { get; init; }
    public required decimal PricePerSquareMeterOnWeekend { get; init; }
}
