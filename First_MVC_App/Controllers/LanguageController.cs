using First_MVC_App.Data;
using First_MVC_App.Models;
using First_MVC_App.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace First_MVC_App.Controllers
{
    public class LanguageController : Controller
    {
        readonly ApplicationDbContext _context;
        public LanguageController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            LanguageViewModel languageViewModel = new()
            {
                Languages = _context.LanguageList.ToList()
            };

            //var person = _context.PeopleList.Include(x => x.LanguageList).FirstOrDefault(x => x.Id == 1);
            //var language = _context.LanguageList.Find(3);

            //person.LanguageList.Add(language);
            //_context.SaveChanges();

            return View("LanguageInxed",languageViewModel);
        }

        public IActionResult Create()
        {         

            return View();
        }

        [HttpPost]
        public IActionResult Create(Language language)
        {
            if (ModelState.IsValid)
            {
                _context.LanguageList.Add(language);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int LanguageId)
        {
           // var languageToRemove = _context.LanguageList.Find(LanguageId);
            var languageToRemove = _context.LanguageList.FirstOrDefault(x=>x.LanguageId == LanguageId);
            if (languageToRemove != null)
            {
                _context.LanguageList.Remove(languageToRemove);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}

