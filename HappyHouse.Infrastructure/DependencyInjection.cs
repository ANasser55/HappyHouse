using HappyHouse.Domain.Interfaces;
using HappyHouse.Infrastructure.Data;
using HappyHouse.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace HappyHouse.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // DbContext
            services.AddDbContext<HappyHouseDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("constr")));

            // Register repositories
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            services.AddScoped<ICustomerRegistrationRepository, CustomerRegistrationRepository>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<IInstallmentsRepository, InstallmentsRepository>();
            services.AddScoped<ILedgerRepository, LedgerRepository>();
            services.AddScoped<ITransactionsRepository, TransactionsRepository>();

            return services;
        }
    }
}
