using DDDLesson.Common;
using DDDLesson.Infrastructure.Repositories.WorkerRepository;
using MediatR;

namespace DDDLesson.Domain.Workers.EditWorker;

public class EditWorkerCommandHandler : IRequestHandler<EditWorkerCommand, WorkerId>
{
    private readonly IWorkerEntityRepository repository;

    public EditWorkerCommandHandler(IWorkerEntityRepository repository)
    {
        this.repository = repository;
    }

    public async Task<WorkerId> Handle(EditWorkerCommand request, CancellationToken cancellationToken)
    {
        var isUpdated = await repository.UpdateAsync(request.Id, workerEntity =>
        {
            workerEntity.Name = request.WorkerName;
            workerEntity.IsInOurShift = request.IsInOurShift;
        });

        if (isUpdated)
        {
            return request.Id;
        }
        throw new Exception("Error update worker.");
    }
}
