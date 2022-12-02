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

        public PeopleController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var people = _context.PeopleList.Include(x => x.City).Include(y => y.LanguageList).ToList();
            //peopleViewModel.people = _context.People.Include(x => x.City).Include(z => z.City.Country).ToList();

            return View(people);
        }

        [HttpPost]
        public IActionResult Create(CreatePersonViewModel cpvm)
        {
            if (ModelState.IsValid)
            {
                Person person = new Person();
                person.Name = cpvm.Person;
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
                CreatePersonViewModel createPersonViewModel = new();

                PeopleViewModel vm = new PeopleViewModel();

                vm.tempList = PeopleViewModel.PeopleList.Where(x => x.Name.Contains(search)).ToList();

                //foreach (var person in createPersonViewModel.GetPeopleList())
                //{
                //    if (!peopleViewModel.CaseSensitive)
                //    {
                //if (person.Name.Contains(search) || person.City.Contains(search))
                //{
                //    peopleViewModel.PeopleList.Add(person);
                //}
                //    }
                //    else
                //    {
                //        if (person.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                //        person.City.Contains(search, StringComparison.OrdinalIgnoreCase))
                //        {
                //            peopleViewModel.PeopleList.Add(person);
                //        }
                //    }
                //}
                return View("PeopleList", vm);
            }

            //ViewBag.Message = $"Showing {peopleViewModel.PeopleList.Count} result(s).";

            return RedirectToAction("PeopleList");
        }

        public IActionResult SortPeople(PeopleViewModel peopleViewModel)
        {
            CreatePersonViewModel createPersonViewModel = new();
            //var people = createPersonViewModel.GetPeopleList();
            //people.Sort((x, y) => string.Compare(x.Name, y.Name));

            return RedirectToAction("PeopleList", peopleViewModel);
        }
    }
}
