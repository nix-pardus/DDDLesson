using DDDLesson.Common;
using DDDLesson.Infrastructure.Persistence.Entities;
using DDDLesson.Infrastructure.Repositories.Common;

namespace DDDLesson.Infrastructure.Repositories.PackagingTypeRepository;

public interface IPackagingTypeEntityRepository : IDbRepository<PackagingTypeId, PackagingTypeEntity>
{
}
