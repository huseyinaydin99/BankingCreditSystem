/// <summary>
/// Sayfalama işlemleri için kullanılan temel parametreleri tutar.
/// </summary>
public class PaginationParams
{
    /// <summary>
    /// Mevcut sayfa numarasını belirtir.
    /// Varsayılan değer 1’dir.
    /// </summary>
    public int PageNumber { get; set; } = 1;

    /// <summary>
    /// Bir sayfada gösterilecek kayıt sayısını belirtir.
    /// Varsayılan değer 10’dur.
    /// </summary>
    public int PageSize { get; set; } = 10;
}

/// <summary>
/// Sayfalanmış veri sonucunu temsil eden generic yapı.
/// </summary>
/// <typeparam name="T">Sayfalanacak veri tipi</typeparam>
public class Paginate<T>
{
    /// <summary>
    /// Mevcut sayfadaki veri listesini tutar.
    /// </summary>
    public IList<T> Items { get; set; }

    /// <summary>
    /// Mevcut sayfa numarasını belirtir.
    /// </summary>
    public int PageNumber { get; set; }

    /// <summary>
    /// Bir sayfada gösterilen kayıt sayısını belirtir.
    /// </summary>
    public int PageSize { get; set; }

    /// <summary>
    /// Toplam sayfa sayısını belirtir.
    /// </summary>
    public int TotalPages { get; set; }

    /// <summary>
    /// Toplam kayıt sayısını belirtir.
    /// </summary>
    public int TotalItems { get; set; }

    /// <summary>
    /// Önceki sayfanın olup olmadığını belirtir.
    /// </summary>
    public bool HasPreviousPage => PageNumber > 1;

    /// <summary>
    /// Sonraki sayfanın olup olmadığını belirtir.
    /// </summary>
    public bool HasNextPage => PageNumber < TotalPages;

    /// <summary>
    /// Boş bir sayfalanmış veri nesnesi oluşturur.
    /// </summary>
    public Paginate()
    {
        Items = new List<T>();
    }

    /// <summary>
    /// Verilen liste, toplam kayıt sayısı ve sayfalama parametrelerine göre
    /// sayfalanmış veri nesnesi oluşturur.
    /// </summary>
    public Paginate(IList<T> items, int totalItems, PaginationParams paginationParams)
    {
        Items = items;
        TotalItems = totalItems;
        PageNumber = paginationParams.PageNumber;
        PageSize = paginationParams.PageSize;
        TotalPages = (int)Math.Ceiling(TotalItems / (double)PageSize);
    }
}