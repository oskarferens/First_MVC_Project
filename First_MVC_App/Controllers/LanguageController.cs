using First_MVC_App.Data;
using First_MVC_App.Models;
using First_MVC_App.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace First_MVC_App.Controllers
{
    public class LanguageController : Controller
    {
        public static LanguageViewModel languageViewModel { get; set; } = new LanguageViewModel();

        readonly ApplicationDbContext _context;
        public LanguageController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        { 
            return View(_context.LanguageList.ToList());
        }

        public IActionResult Create()
        {         

            return View();
        }

        [HttpPost]
        public IActionResult Create(Language language)
        {
            ModelState.Remove("LanguageId");
            ModelState.Remove("PeopleList");
            if (ModelState.IsValid)
            {
                _context.LanguageList.Add(language);
                _context.SaveChanges();s
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int LanguageId)
        {
            var languageToRemove = _context.LanguageList.FirstOrDefault(x => x.LanguageId == LanguageId);
            if (languageToRemove != null)
            {
                _context.LanguageList.Remove(languageToRemove);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}

