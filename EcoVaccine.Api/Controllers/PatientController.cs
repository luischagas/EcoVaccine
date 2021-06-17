using EcoVaccine.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace EcoVaccine.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : BaseController
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

            if (result.Success is false)
                return GenerateResponse(HttpStatusCode.BadRequest, result);

            return GenerateResponse(HttpStatusCode.OK, result);
        }

        #endregion Methods
    }
}