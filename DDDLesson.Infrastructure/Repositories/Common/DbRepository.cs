using DDDLesson.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using System.Transactions;

namespace DDDLesson.Infrastructure.Repositories.Common;

public abstract class DbRepository<TDbContext, TEntityKey, TEntity> : IDbRepository<TEntityKey, TEntity>
    where TDbContext : DbContext
    where TEntity : class, IEntry<TEntityKey>
    where TEntityKey : IEquatable<TEntityKey>, new()
{
    public TDbContext DbContext { get; }
    public DbSet<TEntity> DbSet { get; }
    public event EventHandler RepositoryChanged;

    public DbRepository(TDbContext dbContext)
    {
        DbContext = dbContext;
        DbSet = DbContext.Set<TEntity>();
    }

    public virtual void OnRepositoryChanged()
    {
        RepositoryChanged?.Invoke(this, EventArgs.Empty);
    }

    public async ValueTask<EntityEntry<TEntity>> AddAsync(TEntity entity)
    {
        using var transaction = CreateTransactionScope(IsolationLevel.ReadCommitted);
        var entry = await DbContext.AddAsync(entity);
        await DbContext.SaveChangesAsync();
        transaction.Complete();
        OnRepositoryChanged();
        return entry;
    }

    public async ValueTask<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        using var transaction = CreateTransactionScope(IsolationLevel.ReadCommitted);
        var any = await DbSet.Where(predicate).AnyAsync(cancellationToken);
        transaction.Complete();
        return any;
    }

    public async ValueTask<int> CountAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> buildQuery, CancellationToken cancellationToken)
    {
        using var transaction = CreateTransactionScope(IsolationLevel.ReadCommitted);
        var query = buildQuery(DbSet).AsNoTracking();
        var count = await query.CountAsync(cancellationToken);
        transaction.Complete();
        return count;
    }

    public async ValueTask<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        using var transaction = CreateTransactionScope(IsolationLevel.ReadCommitted);
        var count = await DbSet.Where(predicate).CountAsync(cancellationToken);
        transaction.Complete();
        return count;
    }

    public async Task<bool> DeleteAsync(TEntityKey key)
    {
        using var transaction = CreateTransactionScope(IsolationLevel.ReadCommitted);
        var entity = await DbSet.FindAsync(key);
        if (entity != null)
        {
            DbSet.Remove(entity);
            await DbContext.SaveChangesAsync();
            transaction.Complete();
            OnRepositoryChanged();
            return true;
        }
        transaction.Complete();
        return false;
    }

    public async ValueTask<IReadOnlyCollection<TEntity>> FilterAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> buildQuery, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, CancellationToken cancellationToken)
    {
        using var transaction = CreateTransactionScope(IsolationLevel.ReadCommitted);
        var query = buildQuery(DbSet).AsNoTracking();
        var entities = await orderBy(query).ThenBy(entity => entity.Id).ToArrayAsync(cancellationToken);
        transaction.Complete();
        return entities;
    }

    public async ValueTask<IReadOnlyCollection<TEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        using var transaction = CreateTransactionScope(IsolationLevel.ReadCommitted);
        var entities = await DbSet.AsNoTracking().ToArrayAsync(cancellationToken);
        transaction.Complete();
        return entities;
    }

    public async ValueTask<TProjection?> GetByIdAsync<TProjection>(TEntityKey key, Expression<Func<TEntity, TProjection>> selector, CancellationToken cancellationToken)
    {
        using var transaction = CreateTransactionScope(IsolationLevel.ReadCommitted);

        var projection = await DbSet
            .AsQueryable()
            .Where(q => q.Id.Equals(key))
            .Select(selector)
            .FirstOrDefaultAsync(cancellationToken);
        transaction.Complete();

        return projection;
    }

    public async ValueTask<TEntity?> GetByIdAsync(TEntityKey key, CancellationToken cancellationToken)
    {
        using var transaction = CreateTransactionScope(IsolationLevel.ReadCommitted);

        var entity = await DbSet
            .FirstOrDefaultAsync(entity => entity.Id.Equals(key), cancellationToken);
        transaction.Complete();

        return entity;
    }

    public async Task<Dictionary<TEntityKey, TEntity>> GetByIdsAsync(IReadOnlyCollection<TEntityKey> keys, CancellationToken cancellationToken)
    {
        using var transaction = CreateTransactionScope(IsolationLevel.ReadCommitted);

        var entities = await DbSet
            .AsNoTracking()
            .Where(entity => keys.Contains(entity.Id))
            .ToDictionaryAsync(entity => entity.Id, entity => entity, cancellationToken);
        transaction.Complete();

        return entities;
    }

    public async ValueTask<bool> IsExistIdAsync(TEntityKey key, CancellationToken cancellationToken)
    {
        using var transaction = CreateTransactionScope(IsolationLevel.ReadCommitted);

        var any = await DbSet
            .Where(q => q.Id.Equals(key))
            .AnyAsync(cancellationToken);
        transaction.Complete();

        return any;
    }

    public async ValueTask<bool> UpdateAsync(TEntityKey key, Action<TEntity> updater)
    {
        using var transaction = CreateTransactionScope(IsolationLevel.ReadCommitted);
        var entity = await DbSet.FindAsync(key);

        if (entity != null)
        {
            updater.Invoke(entity);
            await DbContext.SaveChangesAsync();
            transaction.Complete();
            OnRepositoryChanged();
            return true;
        }
        transaction.Complete();
        return false;
    }

    public virtual TransactionScope CreateTransactionScope(IsolationLevel isolationLevel)
    {
        var transactionOptions = new TransactionOptions
        {
            IsolationLevel = isolationLevel
        };
        return new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
    }
}
