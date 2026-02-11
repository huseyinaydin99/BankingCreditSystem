using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Core.CrossCuttingConcerns.Security.Entities;
using BankingCreditSystem.Core.Repositories;
using BankingCreditSystem.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BankingCreditSystem.Persistence.Repositories;

public class ApplicationUserRepository : EfRepositoryBase<ApplicationUser<Guid>, Guid, BaseDbContext>, IApplicationUserRepository
{
    public ApplicationUserRepository(BaseDbContext context) : base(context)
    {
    }

    /// <summary>
    /// Email adresine göre ApplicationUser'ı bulur
    /// </summary>
    public async Task<ApplicationUser<Guid>?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await Context.Set<ApplicationUser<Guid>>()
            .FirstOrDefaultAsync(u => u.Email == email, cancellationToken: cancellationToken);
    }

    /// <summary>
    /// CustomerId'ye göre ApplicationUser'ı bulur
    /// </summary>
    public async Task<ApplicationUser<Guid>?> GetByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken = default)
    {
        return await Context.Set<ApplicationUser<Guid>>()
            .FirstOrDefaultAsync(u => u.CustomerId == customerId, cancellationToken: cancellationToken);
    }
}
