namespace BankingCreditSystem.Core.CrossCuttingConcerns.Security.Services;

/// <summary>
/// Şifre hash ve verify işlemleri için servis
/// </summary>
public interface IPasswordHashingService
{
    /// <summary>
    /// Şifreyi hash'ler ve salt üretir
    /// </summary>
    void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);

    /// <summary>
    /// Verilen şifreyi hash'ленmiş şifre ile doğrular
    /// </summary>
    bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
}
