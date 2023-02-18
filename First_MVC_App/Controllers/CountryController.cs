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
    public class CountryController : Controller
    {
        readonly ApplicationDbContext _context;

        public CountryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            CountryViewModel countryViewModel = new CountryViewModel();
            countryViewModel.countries = _context.Countries.ToList();

            return View(countryViewModel);
        }

        [HttpPost]
        public IActionResult Create(CountryViewModel countryViewModel)
        {

            if (ModelState.IsValid)
            {
                Country country = new Country() { CountryName = countryViewModel.CountryName };
                _context.Countries.Add(country);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult EditPage(int id)
        {
            Country country = _context.Countries.Find(id);
            CountryViewModel countryViewModel = new CountryViewModel();

            countryViewModel.CountryId = id;
            countryViewModel.CountryName = country.CountryName;

            return View(countryViewModel);
        }

        [HttpPost]
        public IActionResult EditCountry(CountryViewModel countryViewModel)
        {
            Country country = _context.Countries.Find(countryViewModel.CountryId);

            if (ModelState.IsValid)
            {
                country.CountryName = countryViewModel.CountryName;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Country country = _context.Countries.Find(id);
            _context.Countries.Remove(country);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}