using BankingCreditSystem.Core.CrossCuttingConcerns.Security.Entities;
using BankingCreditSystem.Core.Repositories;
using BankingCreditSystem.Domain.Entities;
using System;
using System.Security.Cryptography;

public abstract class Customer : Entity<Guid>
{
    public virtual ApplicationUser<Guid> ApplicationUser { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Address { get; set; } = default!;
    public bool IsActive { get; set; }
    
    protected Customer()
    {
        IsActive = true;
    }
} 