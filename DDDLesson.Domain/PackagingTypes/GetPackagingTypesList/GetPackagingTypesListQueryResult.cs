namespace DDDLesson.Domain.PackagingTypes.GetPackagingTypesList;

public class GetPackagingTypesListQueryResult
{
    public required IReadOnlyCollection<GetPackagingTypesListQueryResultEntry> Entries { get; init; }
}
