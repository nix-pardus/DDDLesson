using DDDLesson.Common;
using DDDLesson.Infrastructure.Persistence;
using DDDLesson.Infrastructure.Persistence.Entities;
using DDDLesson.Infrastructure.Repositories.Common;

namespace DDDLesson.Infrastructure.Repositories.WorkUnitRepository;

public class WorkUnitEntityRepository : DbRepository<AppDbContext, WorkUnitId, WorkUnitEntity>, IWorkUnitEntityRepository
{
    public WorkUnitEntityRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
