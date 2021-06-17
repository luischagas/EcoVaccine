using EcoVaccine.Application.Common;
using EcoVaccine.Application.Interfaces;
using EcoVaccine.Application.Models.Patient.Request;
using EcoVaccine.Application.Models.Patient.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EcoVaccine.App.Controllers
{
    public class PatientController : Controller
    {
        #region Fields

        private readonly IPatientService _patientService;

        #endregion Fields

        #region Constructors

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        #endregion Constructors

        #region Methods

        [HttpGet("GetPatient")]
        public async Task<IActionResult> GetPatient()
        {
            var result = await _patientService.GetPatient();

            if (result.Success is false)
                return View("Index", result.Message);

            var patientResponse = result as AppServiceResponse<PatientResponse>;

            return View("Details", patientResponse?.Data);
        }

        [HttpGet("GetToken")]
        public async Task<IActionResult> GetToken()
        {
            var result = await _patientService.GetToken();

            return View("Index", result.Message);
        }
        [HttpGet("UpdatePatient")]
        public async Task<IActionResult> UpdatePatient()
        {
            return View("Edit");
        }

        [HttpPost("UpdatePatient")]
        public async Task<IActionResult> UpdatePatient(PatientRequest request)
        {
            if (ModelState.IsValid is false)
                return View("Edit", request);

            var result = await _patientService.UpdatePatient(request);

            return View("Index", result.Message);
        }

        #endregion Methods
    }
}