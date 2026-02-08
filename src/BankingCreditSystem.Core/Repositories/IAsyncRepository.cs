using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

/// <summary>
/// Asenkron çalışan generic repository arayüzü.
/// Temel CRUD, sorgulama ve sayfalama operasyonlarını tanımlar.
/// </summary>
/// <typeparam name="TEntity">Repository tarafından yönetilen entity tipi</typeparam>
/// <typeparam name="TId">Entity kimlik tipi</typeparam>
public interface IAsyncRepository<TEntity, TId> where TEntity : BankingCreditSystem.Core.Repositories.Entity<TId>
{
    /// <summary>
    /// Verilen koşula göre tek bir entity döndürür.
    /// Include, soft delete ve tracking seçeneklerini destekler.
    /// </summary>
    Task<TEntity?> GetAsync(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Verilen kriterlere göre sayfalanmış entity listesini döndürür.
    /// Filtreleme, sıralama ve include desteği sağlar.
    /// </summary>
    Task<Paginate<TEntity>> GetListAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Verilen koşula göre herhangi bir kayıt olup olmadığını kontrol eder.
    /// </summary>
    Task<bool> AnyAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Yeni bir entity ekler ve veritabanına kaydeder.
    /// </summary>
    Task<TEntity> AddAsync(
        TEntity entity,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Birden fazla entity ekler ve veritabanına kaydeder.
    /// </summary>
    Task<ICollection<TEntity>> AddRangeAsync(
        ICollection<TEntity> entities,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Mevcut bir entity’i günceller.
    /// </summary>
    Task<TEntity> UpdateAsync(
        TEntity entity,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Birden fazla entity’i günceller.
    /// </summary>
    Task<ICollection<TEntity>> UpdateRangeAsync(
        ICollection<TEntity> entities,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Entity’i siler.
    /// Permanent false ise soft delete, true ise fiziksel silme yapar.
    /// </summary>
    Task<TEntity> DeleteAsync(
        TEntity entity,
        bool permanent = false,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Birden fazla entity’i siler.
    /// Permanent false ise soft delete, true ise fiziksel silme yapar.
    /// </summary>
    Task<ICollection<TEntity>> DeleteRangeAsync(
        ICollection<TEntity> entities,
        bool permanent = false,
        CancellationToken cancellationToken = default);
}