using EcoVaccine.Application.Common;
using EcoVaccine.Application.Interfaces;
using EcoVaccine.Application.Models.Patient.Request;
using EcoVaccine.Application.Models.Patient.Response;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using EcoVaccine.Domain.Shared.Services.HealthApi;
using EcoVaccine.Domain.Shared.Utils;
using RestSharp;

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

            if (data.IsSuccessful && string.IsNullOrEmpty(data.Content) is false)
            {
                var healthApiResponse = JsonConvert.DeserializeObject<HealthApiResponse<string>>(data.Content);

                _httpContextAccessor.HttpContext.Session.Set("token", healthApiResponse.Data);

                return new AppServiceResponse<object>(null, "Token obtido com sucesso.", true);
            }

            return new AppServiceResponse<object>(null, "Erro ao obter Token", false);
        }

        public async Task<IAppServiceResponse> GetPatient()
        {
            var token = _httpContextAccessor.HttpContext.Session.Get<string>("token");

            if (token is null)
                return new AppServiceResponse<PatientResponse>(null, "É necessário obter o token primeiro", false);

            var data = _healthApiService.CallMethod(Method.GET, "/api/Desafio/GetPaciente", null, token);

            if (data.IsSuccessful && string.IsNullOrEmpty(data.Content) is false)
            {
                var healthApiResponse = JsonConvert.DeserializeObject<HealthApiResponse<PatientResponse>>(data.Content);

                if (healthApiResponse != null)
                    return new AppServiceResponse<PatientResponse>(healthApiResponse.Data, "Paciente obtido com sucesso.", true);
            }

            return new AppServiceResponse<PatientResponse>(null, "Erro ao obter o Paciente", false);
        }

        public async Task<IAppServiceResponse> UpdatePatient(PatientRequest request)
        {
            var token = _httpContextAccessor.HttpContext.Session.Get<string>("token");

            if (token is null)
                return new AppServiceResponse<PatientResponse>(null, "É necessário obter o token primeiro", false);

            var data = _healthApiService.CallMethod(Method.POST, "/api/Desafio/UpdatePaciente", request, token);

            if (data.IsSuccessful)
                return new AppServiceResponse<string>(null, "Paciente alterado com sucesso.", true);

            return new AppServiceResponse<PatientResponse>(null, "Erro ao alterar o Paciente", false);
        }

        #endregion Methods
    }
}