using DDDLesson.Common;
using DDDLesson.Infrastructure.Repositories.WorkUnitRepository;
using MediatR;

namespace DDDLesson.Domain.WorkUnits.EditWorkUnit;

public class EditWorkUnitCommandHandler : IRequestHandler<EditWorkUnitCommand, WorkUnitId>
{
    private readonly IWorkUnitEntityRepository repository;

    public EditWorkUnitCommandHandler(IWorkUnitEntityRepository repository)
    {
        this.repository = repository;
    }

    public async Task<WorkUnitId> Handle(EditWorkUnitCommand request, CancellationToken cancellationToken)
    {
        var isUpdated = await repository.UpdateAsync(request.WorkUnitId, workUnitEntity =>
        {
            workUnitEntity.Worker = request.Worker;
            workUnitEntity.WorkerId = request.Worker.Id;
            workUnitEntity.WorkDayId = request.WorkDay.Id;
            workUnitEntity.WorkDay = request.WorkDay;
            workUnitEntity.Area = request.Area;
            workUnitEntity.PackagingType = request.PackagingType;
            workUnitEntity.PackagingTypeId = request.PackagingType.Id;
        });

        if (isUpdated)
        {
            return request.WorkUnitId;
        }
        throw new Exception("Error update workUnit");
    }
}
