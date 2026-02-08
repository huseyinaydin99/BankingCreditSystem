namespace BankingCreditSystem.Core.Repositories;

/// <summary>
/// Generic repository arayüzü, tüm entity varlıkları için temel CRUD işlemlerini sağlar.
/// Entity Framework Core ile birlikte asenkron işlemleri destekler.
/// </summary>
/// <typeparam name="TEntity">Entity türü (Entity<TId>'den türemeli)</typeparam>
/// <typeparam name="TId">Entity Id alanının türü</typeparam>
public interface IAsyncRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : notnull
{
    /// <summary>
    /// ID'ye göre tek bir varlığı asenkron olarak getirir.
    /// </summary>
    /// <param name="id">Varlık ID'si</param>
    /// <param name="cancellationToken">İşlem iptal tokeni</param>
    /// <returns>Varlık nesne veya null</returns>
    Task<TEntity?> GetAsync(TId id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Tüm varlıkları sayfalama destekli olarak asenkron olarak getirir.
    /// </summary>
    /// <param name="pageNumber">Sayfa numarası (1'den başlar)</param>
    /// <param name="pageSize">Sayfa başına öğe sayısı</param>
    /// <param name="cancellationToken">İşlem iptal tokeni</param>
    /// <returns>Sayfalanmış varlık listesi</returns>
    Task<PagedResult<TEntity>> GetListAsync(int pageNumber = 1, int pageSize = 10, CancellationToken cancellationToken = default);

    /// <summary>
    /// Belirtilen koşulu sağlayan varlıkları sayfalama destekli olarak asenkron olarak getirir.
    /// </summary>
    /// <param name="predicate">Filtreleme koşulu</param>
    /// <param name="pageNumber">Sayfa numarası</param>
    /// <param name="pageSize">Sayfa başına öğe sayısı</param>
    /// <param name="cancellationToken">İşlem iptal tokeni</param>
    /// <returns>Filtrelenmiş sayfalanmış varlık listesi</returns>
    Task<PagedResult<TEntity>> GetListAsync(
        Func<IQueryable<TEntity>, IQueryable<TEntity>> predicate,
        int pageNumber = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Belirtilen koşulu sağlayan varlık var mı diye kontrol eder.
    /// </summary>
    /// <param name="predicate">Kontrol koşulu</param>
    /// <param name="cancellationToken">İşlem iptal tokeni</param>
    /// <returns>true varlık var ise, false ise</returns>
    Task<bool> AnyAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> predicate, CancellationToken cancellationToken = default);

    /// <summary>
    /// Tek bir varlık ekler.
    /// </summary>
    /// <param name="entity">Eklenecek varlık</param>
    /// <param name="cancellationToken">İşlem iptal tokeni</param>
    /// <returns>Eklenen varlık</returns>
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Birden fazla varlık ekler.
    /// </summary>
    /// <param name="entities">Eklenecek varlık koleksiyonu</param>
    /// <param name="cancellationToken">İşlem iptal tokeni</param>
    /// <returns>Yapılması gereken işlem (SaveChanges çağrılmalı)</returns>
    Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

    /// <summary>
    /// Tek bir varlığı günceller.
    /// </summary>
    /// <param name="entity">Güncellenecek varlık</param>
    /// <param name="cancellationToken">İşlem iptal tokeni</param>
    /// <returns>Güncellenen varlık</returns>
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Birden fazla varlığı günceller.
    /// </summary>
    /// <param name="entities">Güncellenecek varlık koleksiyonu</param>
    /// <param name="cancellationToken">İşlem iptal tokeni</param>
    /// <returns>Yapılması gereken işlem (SaveChanges çağrılmalı)</returns>
    Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

    /// <summary>
    /// Tek bir varlığı siler.
    /// </summary>
    /// <param name="entity">Silinecek varlık</param>
    /// <param name="cancellationToken">İşlem iptal tokeni</param>
    /// <returns>Yapılması gereken işlem (SaveChanges çağrılmalı)</returns>
    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Birden fazla varlığı siler.
    /// </summary>
    /// <param name="entities">Silinecek varlık koleksiyonu</param>
    /// <param name="cancellationToken">İşlem iptal tokeni</param>
    /// <returns>Yapılması gereken işlem (SaveChanges çağrılmalı)</returns>
    Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

    /// <summary>
    /// IQueryable'ı döndürür, böylece kompleks sorgular yazılabilir.
    /// </summary>
    /// <returns>IQueryable nesne</returns>
    IQueryable<TEntity> QueryAsNoTracking();
}
