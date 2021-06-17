using EcoVaccine.Domain.Shared.Services.HealthApi;
using EcoVaccine.Domain.Shared.Services.HealthApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EcoVaccine.Infra.CrossCutting.Services.HealthApi.Extensions
{
   public static class HealthServiceApiConfigurationExtension
    {

        #region Methods

        public static IServiceCollection AddHealthApiCommunication(this IServiceCollection services, IConfiguration configuration)
        {
            var healthApiSettings = new HealthApiSettings();

            configuration.GetSection("HealthApiSettings").Bind(healthApiSettings);

            services.AddSingleton(healthApiSettings);

            services.AddSingleton<IHealthApiService, HealthApiService>();

            return services;
        }

        #endregion Methods
    }


}
