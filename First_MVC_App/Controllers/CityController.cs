using Microsoft.AspNetCore.Mvc;

namespace First_MVC_App.Controllers
{
    public class CityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
