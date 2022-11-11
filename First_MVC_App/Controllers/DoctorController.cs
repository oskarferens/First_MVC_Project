using First_MVC_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace First_MVC_App.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult FeverCheck()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FeverCheck(string temp)
        {
            ViewBag.Message = DoctorModel.CheckTemp(temp);
            return View();
        }

    }
}
