using DDDLesson.Common;
using MediatR;

namespace DDDLesson.Domain.Workers.DeleteWorker;

public class DeleteWorkerCommand : IRequest<bool>
{
    public required WorkerId WorkerId { get; init; }
}
