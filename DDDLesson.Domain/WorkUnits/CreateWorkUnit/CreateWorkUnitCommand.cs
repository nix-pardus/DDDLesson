using DDDLesson.Common;
using MediatR;

namespace DDDLesson.Domain.WorkUnits.CreateWorkUnit;

public class CreateWorkUnitCommand : IRequest<WorkUnitId>
{
    public required WorkerId WorkerId { get; set; }
    public required PackagingTypeId PackagingTypeId { get; set; }
    public required decimal Area { get; set; }
    public required WorkDayId WorkDayId { get; set; }
}
