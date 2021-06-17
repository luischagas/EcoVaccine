using EcoVaccine.Application.Models.Patient.Request;
using System.Threading.Tasks;

namespace EcoVaccine.Application.Interfaces
{
    public interface IPatientService
    {
        #region Methods

        Task<IAppServiceResponse> GetPatient();

        Task<IAppServiceResponse> GetToken();

        Task<IAppServiceResponse> UpdatePatient(PatientRequest request);

        #endregion Methods
    }
}