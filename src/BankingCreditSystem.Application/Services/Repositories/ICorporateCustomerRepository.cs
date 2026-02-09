using BankingCreditSystem.Core.Repositories;

namespace BankingCreditSystem.Application.Services.Repositories;

public interface ICorporateCustomerRepository : IAsyncRepository<CorporateCustomer, Guid>
{
}
