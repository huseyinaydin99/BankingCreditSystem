namespace BankingCreditSystem.Core.Repositories;

/// <summary>
/// Zaman damgası (timestamp) bilgilerini içeren varlıklar için interface.
/// Tüm varlıkların oluşturulma, güncelleme ve silme tarihlerini yönetmek için kullanılır.
/// </summary>
public interface ITimestamp
{
    /// <summary>
    /// Varlığın UTC cinsinden oluşturulma tarihini alır veya ayarlar.
    /// </summary>
    DateTime CreatedDate { get; set; }

    /// <summary>
    /// Varlığın UTC cinsinden son güncellenme tarihini alır veya ayarlar.
    /// </summary>
    DateTime? UpdatedDate { get; set; }

    /// <summary>
    /// Varlığın UTC cinsinden soft delete (mantıksal silme) tarihini alır veya ayarlar.
    /// Null olması, varlığın silinmediğini ifade eder.
    /// </summary>
    DateTime? DeletedDate { get; set; }
}
