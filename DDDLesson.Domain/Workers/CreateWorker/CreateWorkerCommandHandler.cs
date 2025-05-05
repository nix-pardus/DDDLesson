using DDDLesson.Common;
using DDDLesson.Infrastructure.Persistence.Entities;
using DDDLesson.Infrastructure.Repositories.WorkerRepository;
using MediatR;

namespace DDDLesson.Domain.Workers.CreateWorker;

public class CreateWorkerCommandHandler : IRequestHandler<CreateWorkerCommand, WorkerId>
{
    private readonly IWorkerEntityRepository repository;

    public CreateWorkerCommandHandler(IWorkerEntityRepository repository, IMediator mediator)
    {
        this.repository = repository;
    }

    public async Task<WorkerId> Handle(CreateWorkerCommand request, CancellationToken cancellationToken)
    {
        var worker = await repository.AddAsync(new WorkerEntity
        {
            Id = WorkerId.New(),
            Name = request.Name
        });
        return worker.Entity.Id;
    }
}
