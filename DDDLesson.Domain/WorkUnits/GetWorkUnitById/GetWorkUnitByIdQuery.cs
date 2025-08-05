using DDDLesson.Common;
using MediatR;

namespace DDDLesson.Domain.WorkUnits.GetWorkUnitById;

public class GetWorkUnitByIdQuery : IRequest<GetWorkUnitByIdQueryResult>
{
    public required WorkUnitId WorkUnitId { get; init; }
}
