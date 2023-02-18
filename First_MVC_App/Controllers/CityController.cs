using First_MVC_App.Data;
using First_MVC_App.Models;
using First_MVC_App.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace First_MVC_App.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CityController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CityController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            CityViewModel cityViewModel = new CityViewModel();
            cityViewModel.countries = _context.Cities.Include(x => x.Country).ToList();


            ViewBag.Countries = new SelectList(_context.Countries, "CountryId", "CountryName");

            return View(cityViewModel);
        }

        [HttpPost]
        public IActionResult Create(CityViewModel cityViewModel)
        {

            if (ModelState.IsValid)
            {
                City city = new City() { CityName = cityViewModel.Name, CountryId = cityViewModel.CountryId };
                _context.Cities.Add(city);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult EditPage(int id)
        {
            City city = _context.Cities.Find(id);
            CityViewModel cityViewModel = new CityViewModel();

            cityViewModel.Name = city.CityName;
            cityViewModel.CityId = id;
            cityViewModel.CountryId = city.CountryId;

            ViewBag.Countries = new SelectList(_context.Countries, "CountryId", "CountryName");

            return View(cityViewModel);
        }

        [HttpPost]
        public IActionResult EditCity(CityViewModel cityViewModel)
        {
            City city = _context.Cities.Find(cityViewModel.CityId);

            if (ModelState.IsValid)
            {
                city.CityName = cityViewModel.Name;
                city.CountryId = cityViewModel.CountryId;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            City city = _context.Cities.Find(id);
            _context.Cities.Remove(city);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}