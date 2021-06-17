using RestSharp;

namespace EcoVaccine.Domain.Shared.Services.HealthApi
{
    public interface IHealthApiService
    {
        #region Methods

        IRestResponse CallMethod(Method method, string path, object body = null, string token = "");

        #endregion Methods
    }
}