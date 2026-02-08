using BankingCreditSystem.Core.Repositories;

namespace BankingCreditSystem.Domain.Entities;

/// <summary>
/// Kurumsal müşteri varlık sınıfı.
/// Şirketlere özgü alanları içerir.
/// </summary>
public class CorporateCustomer : Customer
{
    /// <summary>
    /// Şirketin adı / Ticari unvanı
    /// </summary>
    public string CompanyName { get; set; } = string.Empty;

    /// <summary>
    /// Şirketin vergi numarası
    /// </summary>
    public string TaxNumber { get; set; } = string.Empty;

    /// <summary>
    /// Şirketin kuruluş tarihi
    /// </summary>
    public DateTime FoundationDate { get; set; }

    /// <summary>
    /// Şirketin sektörü (Finance, Technology, Manufacturing, vb.)
    /// </summary>
    public string Industry { get; set; } = string.Empty;

    /// <summary>
    /// Şirketin türü (Ltd, A.S., Anonim Şirket, vb.)
    /// </summary>
    public string CompanyType { get; set; } = string.Empty;

    /// <summary>
    /// Şirketteki çalışan sayısı
    /// </summary>
    public int EmployeeCount { get; set; }

    /// <summary>
    /// Şirketin yıllık geliri (TL cinsinden)
    /// </summary>
    public decimal AnnualRevenue { get; set; }

    /// <summary>
    /// İletişim görevlisinin adı
    /// </summary>
    public string ContactPersonName { get; set; } = string.Empty;

    /// <summary>
    /// İletişim görevlisinin e-posta adresi
    /// </summary>
    public string ContactPersonEmail { get; set; } = string.Empty;

    /// <summary>
    /// İletişim görevlisinin telefon numarası
    /// </summary>
    public string ContactPersonPhone { get; set; } = string.Empty;

    /// <summary>
    /// Şirketin web sitesi
    /// </summary>
    public string Website { get; set; } = string.Empty;

    /// <summary>
    /// Şirketin kuruluşundan bu yana kaç yılda olduğunu hesaplar
    /// </summary>
    public int YearsInBusiness => DateTime.UtcNow.Year - FoundationDate.Year;

    /// <summary>
    /// Parametre olmayan constructor (ORM için)
    /// </summary>
    protected CorporateCustomer() { }

    /// <summary>
    /// Yeni kurumsal müşteri oluşturur.
    /// </summary>
    public CorporateCustomer(
        string companyName,
        string taxNumber,
        string email,
        string phoneNumber,
        DateTime foundationDate,
        string industry,
        string companyType,
        int employeeCount,
        decimal annualRevenue,
        string contactPersonName,
        string contactPersonEmail,
        string contactPersonPhone,
        string website)
        : base(contactPersonName, string.Empty, contactPersonEmail, contactPersonPhone)
    {
        CompanyName = companyName;
        TaxNumber = taxNumber;
        FoundationDate = foundationDate;
        Industry = industry;
        CompanyType = companyType;
        EmployeeCount = employeeCount;
        AnnualRevenue = annualRevenue;
        ContactPersonName = contactPersonName;
        ContactPersonEmail = contactPersonEmail;
        ContactPersonPhone = contactPersonPhone;
        Website = website;
    }
}
