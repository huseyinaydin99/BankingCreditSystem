using BankingCreditSystem.Domain.Entities;
using BankingCreditSystem.Core.CrossCuttingConcerns.Security.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BankingCreditSystem.Persistence.Contexts;

public class BaseDbContext : DbContext
{
    // Authentication entities
    //public DbSet<User<Guid>> Users { get; set; }
    public DbSet<ApplicationUser<Guid>> ApplicationUsers { get; set; }

    // Customer entities
    public DbSet<Customer> Customers { get; set; }
    public DbSet<IndividualCustomer> IndividualCustomers { get; set; }
    public DbSet<CorporateCustomer> CorporateCustomers { get; set; }

    // Credit entities
    public DbSet<CreditType> CreditTypes { get; set; }
    public DbSet<CreditApplication> CreditApplications { get; set; }

    public BaseDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<User<Guid>>()
        .Ignore(u => u.EmailAuthenticators)
        .Ignore(u => u.OtpAuthenticators)
        .Ignore(u => u.UserOperationClaims)
        .Ignore(u => u.RefreshTokens);

        modelBuilder.Entity<ApplicationUser<Guid>>()
        .Ignore(u => u.EmailAuthenticators)
        .Ignore(u => u.OtpAuthenticators)
        .Ignore(u => u.UserOperationClaims)
        .Ignore(u => u.RefreshTokens);
    }
}
