using DDDLesson.Common;
using DDDLesson.Infrastructure.Persistence.Entities;
using DDDLesson.Infrastructure.Repositories.WorkUnitRepository;
using MediatR;

namespace DDDLesson.Domain.WorkUnits.CreateWorkUnit;

public class CreateWorkUnitCommandHandler : IRequestHandler<CreateWorkUnitCommand, WorkUnitId>
{
    private readonly IWorkUnitEntityRepository repository;

    public CreateWorkUnitCommandHandler(IWorkUnitEntityRepository repository)
    {
        this.repository = repository;
    }

    public async Task<WorkUnitId> Handle(CreateWorkUnitCommand request, CancellationToken cancellationToken)
    {
        var workUnit = await repository.AddAsync(new WorkUnitEntity
        {
            Id = WorkUnitId.New(),
            Area = request.Area,
            PackagingTypeId = request.PackagingTypeId,
            WorkDayId = request.WorkDayId,
            WorkerId = request.WorkerId,
        });
        return workUnit.Entity.Id;
    }
}
