using DDDLesson.Common;
using DDDLesson.Infrastructure.Persistence.Entities;
using DDDLesson.Infrastructure.Repositories.Common;

namespace DDDLesson.Infrastructure.Repositories.WorkDayRepository;

public interface IWorkDayEntityRepository : IDbRepository<WorkDayId, WorkDayEntity>
{
}
