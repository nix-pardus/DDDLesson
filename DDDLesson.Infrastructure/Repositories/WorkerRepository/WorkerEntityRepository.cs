using DDDLesson.Common;
using DDDLesson.Infrastructure.Persistence;
using DDDLesson.Infrastructure.Persistence.Entities;
using DDDLesson.Infrastructure.Repositories.Common;

namespace DDDLesson.Infrastructure.Repositories.WorkerRepository;

public class WorkerEntityRepository : DbRepository<AppDbContext, WorkerId, WorkerEntity>, IWorkerEntityRepository
{
    public WorkerEntityRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
