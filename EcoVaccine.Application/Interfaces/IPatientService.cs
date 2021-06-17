using System.Threading.Tasks;

namespace EcoVaccine.Application.Interfaces
{
    public interface IPatientService
    {
        #region Methods

        Task<IAppServiceResponse> GetToken();

        #endregion Methods
    }
}