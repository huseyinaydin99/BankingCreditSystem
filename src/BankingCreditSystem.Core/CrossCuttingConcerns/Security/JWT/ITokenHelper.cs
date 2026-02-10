using BankingCreditSystem.Core.CrossCuttingConcerns.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BankingCreditSystem.Core.CrossCuttingConcerns.Security.JWT;

public interface ITokenHelper<TId>
{
    AccessToken CreateToken(ApplicationUser<TId> user, IList<OperationClaim<TId>> operationClaims);
    RefreshToken<TId> CreateRefreshToken(ApplicationUser<TId> user, string ipAddress);
}