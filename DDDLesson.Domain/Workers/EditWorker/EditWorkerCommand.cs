using DDDLesson.Common;
using MediatR;

namespace DDDLesson.Domain.Workers.EditWorker;

public class EditWorkerCommand : IRequest<WorkerId>
{
    public required WorkerId Id { get; init; }
    public string WorkerName { get; init; }
}
