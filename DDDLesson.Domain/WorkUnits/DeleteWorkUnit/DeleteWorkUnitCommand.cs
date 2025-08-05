using DDDLesson.Common;
using MediatR;

namespace DDDLesson.Domain.WorkUnits.DeleteWorkUnit;

public class DeleteWorkUnitCommand : IRequest<bool>
{
    public required WorkUnitId Id { get; init; }
}
