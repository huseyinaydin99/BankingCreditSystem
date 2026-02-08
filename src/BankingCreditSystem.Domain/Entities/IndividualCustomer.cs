using BankingCreditSystem.Core.Repositories;

namespace BankingCreditSystem.Domain.Entities;

/// <summary>
/// Bireysel müşteri varlık sınıfı.
/// Kurumsal olmayan müşterilere özgü alanları içerir.
/// </summary>
public class IndividualCustomer : Customer
{
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
    /// Parametre olmayan constructor (ORM için)
    /// </summary>
    protected IndividualCustomer() { }

    /// <summary>
    /// Yeni bireysel müşteri oluşturur.
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
        : base(firstName, lastName, email, phoneNumber)
    {
        IdentityNumber = identityNumber;
        DateOfBirth = dateOfBirth;
        Gender = gender;
        Nationality = nationality;
        MaritalStatus = maritalStatus;
        MonthlyIncome = monthlyIncome;
    }
}
