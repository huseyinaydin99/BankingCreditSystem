using BankingCreditSystem.Core.Repositories;

namespace BankingCreditSystem.Domain.Entities;

/// <summary>
/// Bireysel müşteri varlık sınıfı.
/// Banka sisteminde bireysel müşterileri temsil eder.
/// </summary>
public class IndividualCustomer : Entity<Guid>
{
    /// <summary>
    /// Müşterinin adı
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Müşterinin soyadı
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// Müşterinin elektronik posta adresi
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Müşterinin telefon numarası
    /// </summary>
    public string PhoneNumber { get; set; } = string.Empty;

    /// <summary>
    /// Müşterinin T.C. kimlik numarası
    /// </summary>
    public string IdentityNumber { get; set; } = string.Empty;

    /// <summary>
    /// Müşterinin doğum tarihi
    /// </summary>
    public DateTime DateOfBirth { get; set; }

    /// <summary>
    /// Müşterinin cinsiyeti (M: Erkek, F: Kadın)
    /// </summary>
    public string Gender { get; set; } = string.Empty;

    /// <summary>
    /// Müşterinin uyrukluğu
    /// </summary>
    public string Nationality { get; set; } = string.Empty;

    /// <summary>
    /// Müşterinin medeni durumu (Single, Married, Divorced, Widowed)
    /// </summary>
    public string MaritalStatus { get; set; } = string.Empty;

    /// <summary>
    /// Müşterinin aylık geliri (TL cinsinden)
    /// </summary>
    public decimal MonthlyIncome { get; set; }

    /// <summary>
    /// Müşterinin hesap durumu (Active, Inactive, Closed)
    /// </summary>
    public string AccountStatus { get; set; } = "Active";

    /// <summary>
    /// Tam adını döndürür
    /// </summary>
    public string FullName => $"{FirstName} {LastName}";

    /// <summary>
    /// Yaşını hesaplar
    /// </summary>
    public int Age => DateTime.UtcNow.Year - DateOfBirth.Year;

    /// <summary>
    /// Parametre olmayan constructor
    /// </summary>
    protected IndividualCustomer() { }

    /// <summary>
    /// Bireysel müşteri oluşturur
    /// </summary>
    public IndividualCustomer(
        string firstName,
        string lastName,
        string email,
        string phoneNumber,
        string identityNumber,
        DateTime dateOfBirth,
        string gender,
        string nationality,
        string maritalStatus,
        decimal monthlyIncome)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        IdentityNumber = identityNumber;
        DateOfBirth = dateOfBirth;
        Gender = gender;
        Nationality = nationality;
        MaritalStatus = maritalStatus;
        MonthlyIncome = monthlyIncome;
    }
}
