using First_MVC_App.Data;
using First_MVC_App.Models;
using First_MVC_App.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace First_MVC_App.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CityController : Controller
    {
        public static CityViewModel cityViewModel { get; set; } = new CityViewModel();

        private readonly ApplicationDbContext _context;

        public CityController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            {
                return View(_context.CityList.ToList()); 
            }
        }
            //return View("CityIndex", cityViewModel);
        public IActionResult Create()
        {
            ViewBag.Country = new SelectList(_context.CountryList, "CountryId", "CountryName");

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

        public IActionResult EditPage(int id)
        {
            City city = _context.CityList.Find(id);
            CityViewModel cityViewModel = new CityViewModel();

            cityViewModel.CityName = city.CityName;
            cityViewModel.CityId = id;
            cityViewModel.CountryId = city.CountryId;

            ViewBag.Countries = new SelectList(_context.CountryList, "CountryId", "CountryName");

            return View(cityViewModel);
        }

        [HttpPost]
        public IActionResult EditCity(CityViewModel cityViewModel)
        {
            City city = _context.CityList.Find(cityViewModel.CityId);

            if (ModelState.IsValid)
            {
                city.CityName = cityViewModel.CityName;
                city.CountryId = cityViewModel.CountryId;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int CityId)
        {
            var cityToRemove = _context.CityList.FirstOrDefault(x => x.CityId == CityId);
            if (cityToRemove != null)
            {
                _context.CityList.Remove(cityToRemove);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
