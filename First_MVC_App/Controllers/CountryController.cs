using First_MVC_App.Data;
using First_MVC_App.Models;
using First_MVC_App.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace First_MVC_App.Controllers
{
    public class CountryController : Controller
    {
        readonly ApplicationDbContext _context;

        public CountryController (ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            CountryViewModel countryViewModel = new()
            {
                Countries = _context.CountryList.ToList()
            };

            return View(countryViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Country country)
        {
            if(ModelState.IsValid)
            {
                _context.CountryList.Add(country);
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
