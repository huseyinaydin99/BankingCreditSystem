using BankingCreditSystem.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingCreditSystem.Core.CrossCuttingConcerns.Security.Entities;

public class OperationClaim<TId> : Entity<TId>
{
    public string Name { get; set; }

    public virtual ICollection<UserOperationClaim<TId>> UserOperationClaims { get; set; } = null!;

    public OperationClaim()
    {
        Name = string.Empty;
    }

    public OperationClaim(string name)
    {
        Name = name;
    }

    public OperationClaim(TId id, string name)
        : base(id)
    {
        Name = name;
    }

}