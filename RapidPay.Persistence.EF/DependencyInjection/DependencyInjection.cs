using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RapidPay.Abstractions.Repositories;
using RapidPay.Persistence.EF.Persistence;
using RapidPay.Persistence.EF.Repositories;

namespace RapidPay.Persistence.EF.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<RapidPayDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<ICardRepository, CardRepository>();
            services.AddTransient<IPaymentRepository, PaymentRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }
    }
}
