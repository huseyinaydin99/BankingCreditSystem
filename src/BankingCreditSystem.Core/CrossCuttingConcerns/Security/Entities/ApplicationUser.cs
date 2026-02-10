using System;
using System.Collections.Generic;
using BankingCreditSystem.Core.CrossCuttingConcerns.Security.Entities;

namespace BankingCreditSystem.Core.CrossCuttingConcerns.Security.Entities;

/// <summary>
/// Uygulama düzeyinde kullanıcı modeli. User (authentication) sınıfından miras alır ve
/// Customer (domain) ortak bilgilerini ekler (CustomerId, CustomerType, PhoneNumber, Address, IsActive).
/// 
/// ApplicationUser hem sistem girişi (User) hem de müşteri veri (Customer) taşır.
/// Individual/Corporate özel bilgileri (FirstName, CompanyName vb.) için müşteri entity'si ayrıca fetch edilmelidir.
/// </summary>
public class ApplicationUser<TId> : User<TId>
{
    // ==== Customer (Domain) Common Properties ====
    /// <summary>
    /// Müşteri ID'si (Customer entity'nin Guid ID'si)
    /// </summary>
    public TId CustomerId { get; set; }

    /// <summary>
    /// Müşteri tipi: "Individual" veya "Corporate"
    /// </summary>
    public string CustomerType { get; set; } = string.Empty;

    /// <summary>
    /// Müşteri telefon numarası
    /// </summary>
    public string PhoneNumber { get; set; } = string.Empty;

    /// <summary>
    /// Müşteri adresi
    /// </summary>
    public string Address { get; set; } = string.Empty;

    /// <summary>
    /// Müşteri aktif durumu
    /// </summary>
    public bool IsCustomerActive { get; set; }

    // ==== Role/Authorization Properties ====
    /// <summary>
    /// User'ın sahip olduğu operation claim'ları (roller)
    /// </summary>
    public ICollection<string> OperationClaims { get; set; } = new List<string>();

    // ---- Constructors ----

    public ApplicationUser()
    {
    }

    public ApplicationUser(string email, byte[] passwordSalt, byte[] passwordHash, bool status)
        : base(email, passwordSalt, passwordHash, status)
    {
    }

    public ApplicationUser(TId id, string email, byte[] passwordSalt, byte[] passwordHash, bool status)
        : base(id, email, passwordSalt, passwordHash, status)
    {
    }
}
