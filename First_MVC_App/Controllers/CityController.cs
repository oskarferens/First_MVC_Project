using First_MVC_App.Data;
using First_MVC_App.Models;
using First_MVC_App.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace First_MVC_App.Controllers
{
    public class CityController : Controller
    {
        readonly ApplicationDbContext _context;

        public CityController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            CityViewModel cityViewModel = new()
            {
                Cities = _context.CityList.ToList()
            };
            
            return View("CityIndex", cityViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(City city)
        {
            if (ModelState.IsValid)
            {
                _context.CityList.Add(city);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var countryToRemove = _context.CountryList.Find(id);
            if (countryToRemove != null)
            {
                _context.CountryList.Remove(countryToRemove);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }




    }
}
