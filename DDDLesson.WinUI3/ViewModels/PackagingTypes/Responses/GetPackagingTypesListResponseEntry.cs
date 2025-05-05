using DDDLesson.Common;

namespace DDDLesson.WinUI3.ViewModels.PackagingTypes;

public class GetPackagingTypesListResponseEntry
{
    public required PackagingTypeId Id { get; init; }
    public required string Name { get; init; }
    public required decimal PricePerSquareMeter { get; init; }
    public required decimal PricePerSquareMeterOnWeekend { get; init; }
}
