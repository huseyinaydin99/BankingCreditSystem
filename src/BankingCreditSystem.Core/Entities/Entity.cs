namespace BankingCreditSystem.Core.Entities;

/// <summary>
/// Generic Id alanına sahip temel varlık (entity) sınıfı.
/// Tüm domain varlıkları bu sınıftan türemelidir.
/// </summary>
/// <typeparam name="TId">Varlık kimliğinin tipi (int, Guid, string vb.)</typeparam>
public abstract class Entity<TId> where TId : notnull
{
    /// <summary>
    /// Varlığın benzersiz kimliğini alır veya ayarlar.
    /// Varsayılan değer TId tipine bağlıdır.
    /// </summary>
    public TId Id { get; set; } = default!;

    /// <summary>
    /// Varlığın UTC cinsinden oluşturulma tarihini alır veya ayarlar.
    /// </summary>
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Varlığın UTC cinsinden son güncellenme tarihini alır veya ayarlar.
    /// </summary>
    public DateTime? UpdatedDate { get; set; }

    /// <summary>
    /// Varlığın UTC cinsinden soft delete (mantıksal silme) tarihini alır veya ayarlar.
    /// Null olması, varlığın silinmediğini ifade eder.
    /// </summary>
    public DateTime? DeletedDate { get; set; }

    /// <summary>
    /// İki varlık örneğinin Id değerlerine göre eşit olup olmadığını belirler.
    /// </summary>
    public override bool Equals(object? obj)
    {
        return obj is Entity<TId> entity && Id.Equals(entity.Id);
    }

    /// <summary>
    /// Varlığın Id değerine göre hash kodunu döndürür.
    /// </summary>
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    /// <summary>
    /// Varlığın string temsilini sağlar.
    /// </summary>
    public override string? ToString()
    {
        return $"{GetType().Name} [Id: {Id}]";
    }
}