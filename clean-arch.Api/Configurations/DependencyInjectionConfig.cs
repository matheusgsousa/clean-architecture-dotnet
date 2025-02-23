using clean_arch.Persistence.Repositories;
using clean_arch.Persistence.Repositories.Interfaces;
using clean_arch.Service.Services;
using clean_arch.Service.Services.Interfaces;

namespace clean_arch.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            #region Services
            services.AddScoped<IPaymentService, PaymentService>();
            #endregion

            #region Repositories
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            #endregion
        }
    }
}
