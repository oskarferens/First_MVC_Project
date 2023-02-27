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
        public static PeopleViewModel peopleViewModel = new PeopleViewModel();

        public PeopleController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (PeopleViewModel.PeopleList.Count == 0)
            {
                PeopleViewModel.SeedPeople();
            }

            peopleViewModel.tempList = PeopleViewModel.PeopleList;

            return View(peopleViewModel);
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

        public IActionResult Delete(string Id)
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

            //ViewBag.Message = $"Showing {peopleViewModel.PeopleList.Count} result(s).";

            return RedirectToAction("PeopleList");
        }

        public IActionResult SortPeople(PeopleViewModel peopleViewModel)
        {
            //var people = createPersonViewModel.GetPeopleList();
            //people.Sort((x, y) => string.Compare(x.Name, y.Name));

            return RedirectToAction("PeopleList", peopleViewModel);
        }
    }
}
