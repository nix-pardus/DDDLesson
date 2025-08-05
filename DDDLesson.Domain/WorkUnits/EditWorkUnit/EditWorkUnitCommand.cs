using DDDLesson.Common;
using DDDLesson.Infrastructure.Persistence.Entities;
using MediatR;

namespace DDDLesson.Domain.WorkUnits.EditWorkUnit;

public class EditWorkUnitCommand : IRequest<WorkUnitId>
{
    public required WorkUnitId WorkUnitId { get; init; }

    public required WorkerEntity Worker { get; init; }

    public required PackagingTypeEntity PackagingType { get; init; }

    public required decimal Area { get; init; }

    public required WorkDayEntity WorkDay { get; init; }
}
