using Microsoft.Extensions.DependencyInjection;
using RapidPay.Abstractions.Services;
using RapidPay.Services.Services;

namespace RapidPay.Services.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServicesImplementations(
            this IServiceCollection services)
        {
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddScoped<IUserService, UserService>();
            services.AddTransient<ICardService, CardService>();
            services.AddTransient<IBalanceService, BalanceService>();
            services.AddSingleton<IUniversalFeesExchangeService, UniversalFeesExchangeService>();

            return services;
        }
    }
}
