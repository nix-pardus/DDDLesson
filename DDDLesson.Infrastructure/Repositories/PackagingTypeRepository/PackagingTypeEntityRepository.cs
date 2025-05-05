using DDDLesson.Common;
using DDDLesson.Infrastructure.Persistence;
using DDDLesson.Infrastructure.Persistence.Entities;
using DDDLesson.Infrastructure.Repositories.Common;

namespace DDDLesson.Infrastructure.Repositories.PackagingTypeRepository;

public class PackagingTypeEntityRepository : DbRepository<AppDbContext, PackagingTypeId, PackagingTypeEntity>, IPackagingTypeEntityRepository
{
    public PackagingTypeEntityRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
