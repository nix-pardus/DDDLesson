using DDDLesson.Infrastructure.Repositories.WorkUnitRepository;
using MediatR;

namespace DDDLesson.Domain.WorkUnits.DeleteWorkUnit;

public class DeleteWorkUnitCommandHandler : IRequestHandler<DeleteWorkUnitCommand, bool>
{
    private readonly IWorkUnitEntityRepository repository;

    public DeleteWorkUnitCommandHandler(IWorkUnitEntityRepository repository)
    {
        this.repository = repository;
    }

    public async Task<bool> Handle(DeleteWorkUnitCommand request, CancellationToken cancellationToken)
    {
        var result = await repository.DeleteAsync(request.Id);
        return result;
    }
}
