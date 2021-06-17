using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EcoVaccine.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        #region Methods

        protected IActionResult GenerateResponse(HttpStatusCode statusCode, object result)
            => StatusCode((int)statusCode, result);

        #endregion Methods
    }
}