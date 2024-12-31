using BuildingBlocks.SharedKernel;

namespace HRM.Infrastructure.Data.Repositories;

internal abstract class Repository<T, TId>
    where T : Entity<TId>
{
    protected readonly HRMDbContext DbContext;

    protected Repository(HRMDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<T?> GetByIdAsync(TId id, CancellationToken cancellationToken = default)
    {
        var entity = await DbContext.Set<T>()
            .FindAsync(id, cancellationToken);
        return entity;
    }

    public virtual async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await DbContext.AddAsync(entity, cancellationToken);
    }

    public virtual void Remove(T entity)
    {
        DbContext.Remove(entity);
    }
}
