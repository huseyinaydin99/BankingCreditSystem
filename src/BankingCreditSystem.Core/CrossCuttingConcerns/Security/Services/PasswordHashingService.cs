using BankingCreditSystem.Core.CrossCuttingConcerns.Security.Hashing;

namespace BankingCreditSystem.Core.CrossCuttingConcerns.Security.Services;

/// <summary>
/// Password hashing servisi implementasyonu
/// HashingHelper'ı sarmalayan (wrapper) servis
/// </summary>
public class PasswordHashingService : IPasswordHashingService
{
    /// <summary>
    /// Şifreyi hash'ler ve salt üretir
    /// </summary>
    public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
    }

    /// <summary>
    /// Verilen şifreyi hash'lenmiş şifre ile doğrular
    /// </summary>
    public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        return HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt);
    }
}
