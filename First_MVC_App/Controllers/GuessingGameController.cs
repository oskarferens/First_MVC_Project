using First_MVC_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace First_MVC_App.Controllers
{
    public class GuessingGameController : Controller
    {
        GuessingGameModel GuessingGameModel = new GuessingGameModel();
        public IActionResult GuessingGame()
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("numberSession")))
            {
                int generatedNumber = GuessingGameModel.SetSecretNumber();
                HttpContext.Session.SetInt32("session", generatedNumber);
            }

            return View();
        }

        [HttpPost]
        public IActionResult GuessingGame(int number)
        {
            ViewBag.Message = GuessingGameModel.UserGuessResult(number, HttpContext.Session.GetInt32("session"));

            if (GuessingGameModel.CorrectGuess == true)
            {
                int generatedNumber = GuessingGameModel.SetSecretNumber();
                HttpContext.Session.SetInt32("session", generatedNumber);
            }

            return View(GuessingGameModel);
        }

        [HttpPost]
        public IActionResult Clear()
        {
            int generatedNumber = GuessingGameModel.SetSecretNumber();
            HttpContext.Session.SetInt32("session", generatedNumber);

            ViewBag.Message = string.Empty;


            return View("GuessingGame", GuessingGameModel);
        }
    }
}
