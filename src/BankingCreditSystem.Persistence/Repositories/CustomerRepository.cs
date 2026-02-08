using BankingCreditSystem.Core.Repositories;
using BankingCreditSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using BankingCreditSystem.Persistence.Contexts;
using BankingCreditSystem.Application.Services.Repositories;

namespace BankingCreditSystem.Persistence.Repositories;

public class CustomerRepository<TEntity> : EfRepositoryBase<TEntity, Guid, BaseDbContext>, ICustomerRepository<TEntity>
        where TEntity : Customer
{
    public CustomerRepository(BaseDbContext context) : base(context)
    {
    }
}