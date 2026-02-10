using BankingCreditSystem.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BankingCreditSystem.Core.CrossCuttingConcerns.Security.Entities;

public class OtpAuthenticator<TId> : Entity<TId>
{
    public int UserId { get; set; }
    public byte[] SecretKey { get; set; }
    public bool IsVerified { get; set; }

    public virtual ApplicationUser<TId> User { get; set; } = null!;

    public OtpAuthenticator()
    {
        SecretKey = Array.Empty<byte>();
    }

    public OtpAuthenticator(int userId, byte[] secretKey, bool isVerified)
    {
        UserId = userId;
        SecretKey = secretKey;
        IsVerified = isVerified;
    }

    public OtpAuthenticator(TId id, int userId, byte[] secretKey, bool isVerified)
        : base(id)
    {
        UserId = userId;
        SecretKey = secretKey;
        IsVerified = isVerified;
    }
}
