using BankingCreditSystem.Core.CrossCuttingConcerns.Security.Entities;
using BankingCreditSystem.Core.Repositories;

namespace BankingCreditSystem.Application.Services.Repositories;

public interface IApplicationUserRepository : IAsyncRepository<ApplicationUser<Guid>, Guid>
{
    /// <summary>
    /// Email adresine göre ApplicationUser'ı bulur
    /// </summary>
    Task<ApplicationUser<Guid>?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);

    /// <summary>
    /// CustomerId'ye göre ApplicationUser'ı bulur
    /// </summary>
    Task<ApplicationUser<Guid>?> GetByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken = default);
}
