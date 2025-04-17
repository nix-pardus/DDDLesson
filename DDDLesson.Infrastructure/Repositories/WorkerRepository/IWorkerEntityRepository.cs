using DDDLesson.Common;
using DDDLesson.Infrastructure.Persistence.Entities;
using DDDLesson.Infrastructure.Repositories.Common;

namespace DDDLesson.Infrastructure.Repositories.WorkerRepository;

public interface IWorkerEntityRepository : IDbRepository<WorkerId, WorkerEntity>
{
}
