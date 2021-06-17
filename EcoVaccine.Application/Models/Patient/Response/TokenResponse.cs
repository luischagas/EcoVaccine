namespace EcoVaccine.Application.Models.Patient.Response
{
    public class TokenResponse
    {
        #region Constructors

        public TokenResponse(string message)
        {
            Message = message;
        }

        #endregion Constructors

        #region Properties

        public string Message { get; set; }

        #endregion Properties
    }
}