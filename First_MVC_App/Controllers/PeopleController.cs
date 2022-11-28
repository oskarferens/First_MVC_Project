using Microsoft.AspNetCore.Mvc;
using System;
using First_MVC_App.Models;
using First_MVC_App.ViewModels;

namespace First_MVC_App.Controllers
{
    public class PeopleController : Controller
    {
        public static PeopleViewModel peopleViewModel { get; set; } = new PeopleViewModel();
        static private int _indexer;
        public IActionResult PeopleList()
        {
            if (PeopleViewModel.PeopleList.Count() == 0)
            {
                PeopleViewModel.SeedPeople();
                _indexer = PeopleViewModel.PeopleList.Count();
                peopleViewModel.tempList = PeopleViewModel.PeopleList;
            }
            peopleViewModel.cpvm = new();

            return View(peopleViewModel);
        }

        [HttpPost]
        public IActionResult CreatePerson(CreatePersonViewModel cpvm)
        {
            peopleViewModel.cpvm = new();
            if (ModelState.IsValid)
            {
                //PeopleViewModel peopleViewModel = new();
                Person person = new Person();
                person.Name = cpvm.Name;
                person.PhoneNumber = cpvm.PhoneNumber;
                //person.City = cpvm.City;
                //_indexer++;
                person.Id = ++_indexer;
                //peopleViewModel.CreatePerson(cpvm.Name, cpvm.PhoneNumber, cpvm.City);
                //peopleViewModel.PeopleList = peopleViewModel.GetPeopleList();
                PeopleViewModel.PeopleList.Add(person);

            }
            else
            {
                return RedirectToAction("PeopleList");
            }

            return RedirectToAction("PeopleList");
        }


        public IActionResult DeletePerson(int id)
        {
            Person p = PeopleViewModel.PeopleList.FirstOrDefault(p => p.Id == id);
            PeopleViewModel.PeopleList.Remove(p);
            //createPersonViewModel.DeletePerson(person);
            return RedirectToAction("PeopleList");
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
