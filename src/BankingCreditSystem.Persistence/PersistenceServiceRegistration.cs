using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using BankingCreditSystem.Persistence.Contexts;
using BankingCreditSystem.Persistence.Repositories;
using BankingCreditSystem.Application.Services.Repositories;
using Microsoft.Extensions.Configuration;

namespace BankingCreditSystem.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        // DbContext
        services.AddDbContext<BaseDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        // Repositories
        services.AddScoped<IIndividualCustomerRepository, IndividualCustomerRepository>();
        services.AddScoped<ICorporateCustomerRepository, CorporateCustomerRepository>();

        return services;
    }
} 