using BankingCreditSystem.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BankingCreditSystem.Core.CrossCuttingConcerns.Security.Entities;

public class UserOperationClaim<TId> : Entity<TId>
{
    public int UserId { get; set; }
    public int OperationClaimId { get; set; }

    public virtual ApplicationUser<TId> User { get; set; }
    public virtual OperationClaim<TId> OperationClaim { get; set; }

    public UserOperationClaim(int userId, int operationClaimId)
    {
        UserId = userId;
        OperationClaimId = operationClaimId;
    }

    public UserOperationClaim(TId id, int userId, int operationClaimId)
        : base(id)
    {
        UserId = userId;
        OperationClaimId = operationClaimId;
    }
}
