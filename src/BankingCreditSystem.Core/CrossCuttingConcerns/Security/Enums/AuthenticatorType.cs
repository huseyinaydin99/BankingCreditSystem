using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingCreditSystem.Core.CrossCuttingConcerns.Security.Enums;

public enum AuthenticatorType
{
    None = 0,
    Email = 1,
    Otp = 2
}
