using BankingCreditSystem.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingCreditSystem.Core.CrossCuttingConcerns.Security.Entities;

public class EmailAuthenticator<TId> : Entity<TId>
{
    public int UserId { get; set; }
    public string? ActivationKey { get; set; }
    public bool IsVerified { get; set; }

    public virtual ApplicationUser<TId> User { get; set; } = null!;

    public EmailAuthenticator() { }

    public EmailAuthenticator(int userId, bool isVerified)
    {
        UserId = userId;
        IsVerified = isVerified;
    }

    public EmailAuthenticator(TId id, int userId, bool isVerified)
        : base(id)
    {
        UserId = userId;
        IsVerified = isVerified;
    }
}
