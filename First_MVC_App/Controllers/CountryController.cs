using First_MVC_App.Data;
using First_MVC_App.Models;
using First_MVC_App.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace First_MVC_App.Controllers
{
    public class CountryController : Controller
    {
        public static CountryViewModel countryViewModel { get; set; } = new CountryViewModel();

        readonly ApplicationDbContext _context;
        static private int _indexer;
        public CountryController (ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (CountryViewModel.CountryList.Count() == 0)
            {
                _indexer = CountryViewModel.CountryList.Count();
                countryViewModel.TempList = _context.CountryList.Include(x => x.CityList).ToList();
            }
            //countryViewModel.ccvm = new();

            return View(_context.CountryList.ToList());
        }
            //CountryViewModel countryViewModel = new()
            //{
            //    Countries = _context.CountryList.ToList()
            //};

            //return View();

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Country country)
        {
            ModelState.Remove("Id");
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
