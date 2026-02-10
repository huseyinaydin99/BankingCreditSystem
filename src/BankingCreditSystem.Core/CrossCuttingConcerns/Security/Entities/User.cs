using BankingCreditSystem.Core.Repositories;
using BankingCreditSystem.Core.CrossCuttingConcerns.Security.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingCreditSystem.Core.CrossCuttingConcerns.Security.Entities;

public class User<TId> : Entity<TId>
{
    public string Email { get; set; }
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }
    public bool Status { get; set; }

    public AuthenticatorType AuthenticatorType { get; set; }

    public virtual ICollection<UserOperationClaim<TId>> UserOperationClaims { get; set; } = null!;
    public virtual ICollection<RefreshToken<TId>> RefreshTokens { get; set; } = null!;
    public virtual ICollection<OtpAuthenticator<TId>> OtpAuthenticators { get; set; } = null!;
    public virtual ICollection<EmailAuthenticator<TId>> EmailAuthenticators { get; set; } = null!;

    public User()
    {
        Email = string.Empty;
        PasswordHash = Array.Empty<byte>();
        PasswordSalt = Array.Empty<byte>();
    }

    public User(string email, byte[] passwordSalt, byte[] passwordHash, bool status)
    {
        Email = email;
        PasswordSalt = passwordSalt;
        PasswordHash = passwordHash;
        Status = status;
    }

    public User(TId id, string email, byte[] passwordSalt, byte[] passwordHash, bool status) : base(id)
    {
        Id = id;
        Email = email;
        PasswordSalt = passwordSalt;
        PasswordHash = passwordHash;
        Status = status;
    }
}
