using DDDLesson.Common;
using DDDLesson.Infrastructure.Persistence;
using DDDLesson.Infrastructure.Persistence.Entities;
using DDDLesson.Infrastructure.Repositories.Common;

namespace DDDLesson.Infrastructure.Repositories.WorkDayRepository;

public class WorkDayEntityRepository : DbRepository<AppDbContext, WorkDayId, WorkDayEntity>, IWorkDayEntityRepository
{
    public WorkDayEntityRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
