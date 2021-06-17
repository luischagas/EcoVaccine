namespace EcoVaccine.Application.Common
{
    public class HealthApiResponse
    {
        #region Properties

        public string Data { get; set; }
        public string Mensagem { get; set; }
        public string ProximaEtapa { get; set; }
        public int StatusCode { get; set; }

        #endregion Properties
    }
}