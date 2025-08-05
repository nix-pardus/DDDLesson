using DDDLesson.Common;
using DDDLesson.Infrastructure.Persistence.Entities;
using DDDLesson.Infrastructure.Repositories.Common;

namespace DDDLesson.Infrastructure.Repositories.WorkUnitRepository;

public interface IWorkUnitEntityRepository : IDbRepository<WorkUnitId, WorkUnitEntity>
{
}
