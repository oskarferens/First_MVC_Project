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
    [Authorize(Roles = "Admin, User")]
    public class HomeController : Controller
    {

        readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            PeopleViewModel peopleViewModel = new PeopleViewModel();
            peopleViewModel.people = _context.People.Include(x => x.City).Include(z => z.City.Country).ToList();

            ViewBag.Cities = new SelectList(_context.Cities, "CityId", "CityName");

            return View(peopleViewModel);
        }

        [HttpPost]
        public IActionResult Create(CreatePersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.People.Add(new Person { Name = model.Name, PhoneNumber = model.PhoneNumber, CityId = model.CityId });
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult EditPage(int id)
        {
            Person person = _context.People.Find(id);
            PersonViewModel personViewModel = new PersonViewModel();

            personViewModel.PersonId = id;
            personViewModel.Name = person.Name;
            personViewModel.PhoneNumber = person.PhoneNumber;
            personViewModel.CityId = person.CityId;

            ViewBag.Cities = new SelectList(_context.Cities, "CityId", "CityName");

            return View(personViewModel);
        }

        [HttpPost]
        public IActionResult EditPerson(PersonViewModel personViewModel)
        {
            Person person = _context.People.Find(personViewModel.PersonId);

            if (ModelState.IsValid)
            {
                person.Name = personViewModel.Name;
                person.PhoneNumber = personViewModel.PhoneNumber;
                person.CityId = personViewModel.CityId;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Person person = _context.People.Find(id);
            _context.People.Remove(person);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}