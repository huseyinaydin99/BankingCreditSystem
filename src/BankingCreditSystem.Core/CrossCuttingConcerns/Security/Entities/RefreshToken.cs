using BankingCreditSystem.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingCreditSystem.Core.CrossCuttingConcerns.Security.Entities;

public class RefreshToken<TId> : Entity<TId>
{
    public TId UserId { get; set; }
    public string Token { get; set; }
    public DateTime Expires { get; set; }
    public string CreatedByIp { get; set; }
    public DateTime? Revoked { get; set; }
    public string? RevokedByIp { get; set; }
    public string? ReplacedByToken { get; set; }
    public string? ReasonRevoked { get; set; }

    public virtual ApplicationUser<TId> User { get; set; } = null!;

    public RefreshToken()
    {
        Token = string.Empty;
        CreatedByIp = string.Empty;
    }

    public RefreshToken(TId userId, string token, DateTime expires, string createdByIp)
    {
        UserId = userId;
        Token = token;
        Expires = expires;
        CreatedByIp = createdByIp;
    }

    public RefreshToken(TId id, TId userId, string token, DateTime expires, string createdByIp)
        : base(id)
    {
        UserId = userId;
        Token = token;
        Expires = expires;
        CreatedByIp = createdByIp;
    }
}
