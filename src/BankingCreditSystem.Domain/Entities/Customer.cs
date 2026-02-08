using BankingCreditSystem.Core.Repositories;

namespace BankingCreditSystem.Domain.Entities;

/// <summary>
/// Bankacılık sistemindeki bir müşteri varlığını temsil eder.
/// Generic Entity temel sınıfının kullanımını gösteren örnek bir varlıktır.
/// </summary>
public class Customer : Entity<Guid>
{
    /// <summary>
    /// Müşterinin adını alır veya ayarlar.
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Müşterinin soyadını alır veya ayarlar.
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// Müşterinin e-posta adresini alır veya ayarlar.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Müşterinin telefon numarasını alır veya ayarlar.
    /// </summary>
    public string PhoneNumber { get; set; } = string.Empty;

    /// <summary>
    /// Müşterinin tam görünen adını döndürür.
    /// </summary>
    public string FullName => $"{FirstName} {LastName}";

    /// <summary>
    /// ORM tarafından gerekli olan parametresiz yapıcı metot.
    /// </summary>
    protected Customer() { }

    /// <summary>
    /// Yeni bir müşteri örneği oluşturur.
    /// </summary>
    public Customer(string firstName, string lastName, string email, string phoneNumber)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
    }
}