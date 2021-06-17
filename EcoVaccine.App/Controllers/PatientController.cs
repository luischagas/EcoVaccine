using EcoVaccine.Application.Common;
using EcoVaccine.Application.Interfaces;
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

        [HttpGet("GetToken")]
        public async Task<IActionResult> GetToken()
        {
            var result = await _patientService.GetToken();

            return View("Token", result.Message);
        }

        #endregion Methods
    }
}