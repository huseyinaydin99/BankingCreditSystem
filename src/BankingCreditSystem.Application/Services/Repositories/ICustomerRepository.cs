using BankingCreditSystem.Domain.Entities;
using BankingCreditSystem.Core.Repositories;

namespace BankingCreditSystem.Application.Services.Repositories;

public interface ICustomerRepository<TEntity> : IAsyncRepository<TEntity, Guid> where TEntity : Customer
{
}