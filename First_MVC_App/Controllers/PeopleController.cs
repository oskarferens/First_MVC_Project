using Microsoft.AspNetCore.Mvc;
using System;
using First_MVC_App.Models;
using First_MVC_App.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using First_MVC_App.Data;

namespace First_MVC_App.Controllers
{
    public class PeopleController : Controller
    {
        private readonly ApplicationDbContext _context;
        public static PeopleViewModel peopleViewModel { get; set; } = new PeopleViewModel();

        public PeopleController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var people = _context.PeopleList.Include(x => x.City).Include(y => y.LanguageList).ToList();
            return View(people);
        }

        public IActionResult Create()
        {
            ViewBag.Cities = new SelectList(_context.CityList, "CityId", "CityName");
            ViewBag.Languages = new SelectList(_context.LanguageList, "LanguageId", "Name");
            return View();
        }


        [HttpPost]
        public IActionResult Create(Person person)
        {
           
           var language = _context.LanguageList.FirstOrDefault(x => x.LanguageId == person.LanguageId);
           person.LanguageList.Add(language);
            ModelState.Remove("City");
            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                _context.PeopleList.Add(person);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var personToRemove = _context.PeopleList.FirstOrDefault(x => x.Id == Id);
            if (personToRemove != null)
            {
                _context.PeopleList.Remove(personToRemove);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Search(PeopleViewModel peopleViewModel)
        {
            if (peopleViewModel.Search != null)
            {
                var search = peopleViewModel.Search;

                PeopleViewModel vm = new PeopleViewModel();

                vm.tempList = PeopleViewModel.PeopleList.Where(x => x.Name.Contains(search)).ToList();

                return View("PeopleList", vm);
            }

            return RedirectToAction("PeopleList");
        }

        public IActionResult SortPeople(PeopleViewModel peopleViewModel)
        {
            return RedirectToAction("PeopleList", peopleViewModel);
        }
    }
}
