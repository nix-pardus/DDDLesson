using DDDLesson.Common;
using DDDLesson.Infrastructure.Persistence.Entities;

namespace DDDLesson.Domain.WorkUnits.GetWorkUnitById;

public class GetWorkUnitByIdQueryResult
{
    public required WorkUnitId Id { get; init; }

    public required WorkerEntity Worker { get; init; }

    public required PackagingTypeEntity PackagingType { get; init; }

    public required decimal Area { get; init; }

    public required WorkDayEntity WorkDay { get; init; }
}
