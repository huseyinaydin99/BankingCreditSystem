using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Persistence.Contexts;

namespace BankingCreditSystem.Persistence.Repositories;

public class CorporateCustomerRepository : CustomerRepository<CorporateCustomer>, ICorporateCustomerRepository
{
    public CorporateCustomerRepository(BaseDbContext context) : base(context)
    {
    }
}