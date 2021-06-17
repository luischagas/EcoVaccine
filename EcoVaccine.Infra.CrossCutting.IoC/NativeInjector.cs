using EcoVaccine.Application.Interfaces;
using EcoVaccine.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EcoVaccine.Infra.CrossCutting.IoC
{
    public static class NativeInjector
    {
        #region Methods

        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IPatientService, PatientService>();

            return services;
        }

        #endregion Methods
    }
}