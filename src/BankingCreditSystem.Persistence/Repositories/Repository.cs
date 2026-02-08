using BankingCreditSystem.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BankingCreditSystem.Persistence.Repositories;

/// <summary>
/// Generic repository implementasyonu.
/// Entity Framework Core'u kullanarak CRUD operasyonlarını gerçekleştirir.
/// </summary>
/// <typeparam name="TEntity">Entity türü</typeparam>
/// <typeparam name="TId">Entity Id alanının türü</typeparam>
public class Repository<TEntity, TId> : IRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : notnull
{
    private readonly DbContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="dbContext">Entity Framework Core DbContext</param>
    public Repository(DbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<TEntity>();
    }

    /// <summary>
    /// ID'ye göre tek bir varlığı asenkron olarak getirir.
    /// </summary>
    public async Task<TEntity?> GetAsync(TId id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FirstOrDefaultAsync(e => e.Id.Equals(id), cancellationToken);
    }

    /// <summary>
    /// Tüm varlıkları sayfalama destekli olarak asenkron olarak getirir.
    /// </summary>
    public async Task<PagedResult<TEntity>> GetListAsync(
        int pageNumber = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        // Sayfa numarasını kontrol et
        if (pageNumber < 1) pageNumber = 1;
        if (pageSize < 1) pageSize = 10;

        // Toplam kayıt sayısını al
        var totalCount = await _dbSet.CountAsync(cancellationToken);

        // Varlıkları al
        var items = await _dbSet
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new PagedResult<TEntity>(items, pageNumber, pageSize, totalCount);
    }

    /// <summary>
    /// Belirtilen koşulu sağlayan varlıkları sayfalama destekli olarak asenkron olarak getirir.
    /// </summary>
    public async Task<PagedResult<TEntity>> GetListAsync(
        Func<IQueryable<TEntity>, IQueryable<TEntity>> predicate,
        int pageNumber = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        // Sayfa numarasını kontrol et
        if (pageNumber < 1) pageNumber = 1;
        if (pageSize < 1) pageSize = 10;

        // Sorguyu oluştur
        var query = predicate(_dbSet);

        // Toplam kayıt sayısını al
        var totalCount = await query.CountAsync(cancellationToken);

        // Varlıkları al
        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new PagedResult<TEntity>(items, pageNumber, pageSize, totalCount);
    }

    /// <summary>
    /// Belirtilen koşulu sağlayan varlık var mı diye kontrol eder.
    /// </summary>
    public async Task<bool> AnyAsync(
        Func<IQueryable<TEntity>, IQueryable<TEntity>> predicate,
        CancellationToken cancellationToken = default)
    {
        var query = predicate(_dbSet);
        return await query.AnyAsync(cancellationToken);
    }

    /// <summary>
    /// Tek bir varlık ekler.
    /// </summary>
    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var addedEntity = await _dbSet.AddAsync(entity, cancellationToken);
        return addedEntity.Entity;
    }

    /// <summary>
    /// Birden fazla varlık ekler.
    /// </summary>
    public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddRangeAsync(entities, cancellationToken);
    }

    /// <summary>
    /// Tek bir varlığı günceller.
    /// </summary>
    public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _dbSet.Update(entity);
        await Task.CompletedTask;
        return entity;
    }

    /// <summary>
    /// Birden fazla varlığı günceller.
    /// </summary>
    public async Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        _dbSet.UpdateRange(entities);
        await Task.CompletedTask;
    }

    /// <summary>
    /// Tek bir varlığı siler.
    /// </summary>
    public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _dbSet.Remove(entity);
        await Task.CompletedTask;
    }

    /// <summary>
    /// Birden fazla varlığı siler.
    /// </summary>
    public async Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        _dbSet.RemoveRange(entities);
        await Task.CompletedTask;
    }

    /// <summary>
    /// IQueryable'ı döndürür - AsNoTracking ile sorgu performansını artırır.
    /// </summary>
    public IQueryable<TEntity> QueryAsNoTracking()
    {
        return _dbSet.AsNoTracking();
    }
}
