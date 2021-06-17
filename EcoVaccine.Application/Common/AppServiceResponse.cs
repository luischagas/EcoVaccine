using EcoVaccine.Application.Interfaces;
using Newtonsoft.Json;

namespace EcoVaccine.Application.Common
{
    public class AppServiceResponse<T> : IAppServiceResponse where T : class
    {
        #region Constructors

        public AppServiceResponse(T data, string message, bool success)
        {
            Data = data;
            Message = message;
            Success = success;
        }

        protected AppServiceResponse()
        {
        }

        #endregion Constructors

        #region Properties

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }

        #endregion Properties
    }
}