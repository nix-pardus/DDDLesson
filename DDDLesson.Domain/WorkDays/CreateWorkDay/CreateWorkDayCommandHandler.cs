using DDDLesson.Common;
using DDDLesson.Infrastructure.Persistence.Entities;
using DDDLesson.Infrastructure.Repositories.WorkDayRepository;
using MediatR;

namespace DDDLesson.Domain.WorkDays.CreateWorkDay;

public class CreateWorkDayCommandHandler : IRequestHandler<CreateWorkDayCommand, WorkDayId>
{
    private readonly IWorkDayEntityRepository workDayEntityRepository;

    public CreateWorkDayCommandHandler(IWorkDayEntityRepository workDayEntityRepository)
    {
        this.workDayEntityRepository = workDayEntityRepository;
    }

    public async Task<WorkDayId> Handle(CreateWorkDayCommand request, CancellationToken cancellationToken)
    {
        var workDay = await workDayEntityRepository.AddAsync(new WorkDayEntity
        {
            Date = request.Date,
            Id = WorkDayId.New(),
            IsWeekend = request.IsWeekend,
        });
        return workDay.Entity.Id;
    }
}
