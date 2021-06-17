using Microsoft.AspNetCore.Mvc;

namespace EcoVaccine.App.Controllers
{
    public class HomeController : Controller
    {
        #region Constructors

        public HomeController()
        {
        }

        #endregion Constructors

        #region Methods

        public IActionResult Index()
        {
            return View();
        }

        #endregion Methods
    }
}