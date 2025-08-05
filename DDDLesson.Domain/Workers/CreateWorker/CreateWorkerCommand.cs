using DDDLesson.Common;
using MediatR;

namespace DDDLesson.Domain.Workers.CreateWorker;

public class CreateWorkerCommand : IRequest<WorkerId>
{
    public required string Name { get; init; }
    public required bool IsInOurShift { get; init; }
}
