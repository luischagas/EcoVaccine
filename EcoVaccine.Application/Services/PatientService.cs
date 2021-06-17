using EcoVaccine.Application.Common;
using EcoVaccine.Application.Interfaces;
using EcoVaccine.Domain.Shared.Services.HealthApi;
using EcoVaccine.Domain.Shared.Utils;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;

namespace EcoVaccine.Application.Services
{
    public class PatientService : IPatientService
    {
        #region Fields

        private readonly IHealthApiService _healthApiService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion Fields

        #region Constructors

        public PatientService(IHealthApiService healthApiService, IHttpContextAccessor httpContextAccessor)
        {
            _healthApiService = healthApiService;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion Constructors

        #region Methods

        public async Task<IAppServiceResponse> GetToken()
        {
            var data = _healthApiService.CallMethod(Method.GET, "/api/Desafio/GetToken");

            if (data.IsSuccessful)
            {
                if (string.IsNullOrEmpty(data.Content) is false)
                {
                    var healthApiResponse = JsonConvert.DeserializeObject<HealthApiResponse>(data.Content);

                    _httpContextAccessor.HttpContext.Session.Set("token", healthApiResponse.Data);

                    var teste = _httpContextAccessor.HttpContext.Session.Get<string>("token");

                    return new AppServiceResponse<object>(null, "Token obtido com sucesso.", true);
                }
            }

            return new AppServiceResponse<object>(null, "Erro ao obter Token", false);
        }

        #endregion Methods
    }
}