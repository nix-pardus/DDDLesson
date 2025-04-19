using DDDLesson.Infrastructure.Repositories.WorkerRepository;
using MediatR;

namespace DDDLesson.Domain.Workers.DeleteWorker;

public class DeleteWorkerCommandHandler : IRequestHandler<DeleteWorkerCommand, bool>
{
    private readonly IWorkerEntityRepository repository;

    public DeleteWorkerCommandHandler(IWorkerEntityRepository repository)
    {
        this.repository = repository;
    }

    public async Task<bool> Handle(DeleteWorkerCommand request, CancellationToken cancellationToken)
    {
        var result = await repository.DeleteAsync(request.WorkerId);
        return result;
    }
}
