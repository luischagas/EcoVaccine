using EcoVaccine.Domain.Shared.Services.HealthApi;
using EcoVaccine.Domain.Shared.Services.HealthApi.Models;
using Newtonsoft.Json;
using RestSharp;

namespace EcoVaccine.Infra.CrossCutting.Services.HealthApi
{
    public class HealthApiService : IHealthApiService
    {
        #region Fields

        private readonly HealthApiSettings _settings;

        #endregion Fields

        #region Constructors

        public HealthApiService(HealthApiSettings settings)
        {
            _settings = settings;
        }

        #endregion Constructors

        #region Methods

        public IRestResponse CallMethod(Method method, string path, object body = null, string token = "")
        {
            var client = new RestClient($"{_settings.Url}{path}")
            {
                Timeout = -1
            };

            var request = new RestRequest(method);

            request.AddHeader("Content-Type", "application/json");

            if (string.IsNullOrEmpty(token) is false)
                request.AddHeader("authorization", $"Bearer {token}");

            if (body != null)
                request.AddParameter("application/json", JsonConvert.SerializeObject(body), ParameterType.RequestBody);

            return client.Execute(request);
        }

        #endregion Methods
    }
}