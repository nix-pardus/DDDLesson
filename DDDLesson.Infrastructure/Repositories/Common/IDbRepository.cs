using DDDLesson.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace DDDLesson.Infrastructure.Repositories.Common;

public interface IDbRepository<TEntityKey, TEntity>
    where TEntity : class, IEntry<TEntityKey>
    where TEntityKey : IEquatable<TEntityKey>, new()
{
    public event EventHandler RepositoryChanged;
    ValueTask<EntityEntry<TEntity>> AddAsync(TEntity entity);
    ValueTask<bool> UpdateAsync(TEntityKey key, Action<TEntity> updater);
    ValueTask<IReadOnlyCollection<TEntity>> GetAllAsync(CancellationToken cancellationToken);
    ValueTask<TProjection?> GetByIdAsync<TProjection>
    (
        TEntityKey key,
        Expression<Func<TEntity, TProjection>> selector,
        CancellationToken cancellationToken
    );
    ValueTask<TEntity?> GetByIdAsync(TEntityKey key, CancellationToken cancellationToken);
    ValueTask<bool> IsExistIdAsync(TEntityKey key, CancellationToken cancellationToken);
    Task<Dictionary<TEntityKey, TEntity>> GetByIdsAsync(IReadOnlyCollection<TEntityKey> keys, CancellationToken cancellationToken);
    ValueTask<IReadOnlyCollection<TEntity>> FilterAsync
    (
        Func<IQueryable<TEntity>, IQueryable<TEntity>> buildQuery,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
        CancellationToken cancellationToken
    );
    ValueTask<int> CountAsync
    (
        Func<IQueryable<TEntity>, IQueryable<TEntity>> buildQuery,
        CancellationToken cancellationToken
    );

    ValueTask<int> CountAsync
    (
        Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken
    );

    ValueTask<bool> AnyAsync
    (
        Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken
    );

    Task<bool> DeleteAsync(TEntityKey key);
}
