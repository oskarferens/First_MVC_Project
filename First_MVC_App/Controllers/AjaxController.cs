using First_MVC_App.Models;
using First_MVC_App.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace First_MVC_App.Controllers
{
    public class AjaxController : Controller
    {
        public static PeopleViewModel vm = new PeopleViewModel();

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetPeople()
        {
            if (PeopleViewModel.PeopleList.Count == 0)
            {
                PeopleViewModel.SeedPeople();
            }

            vm.tempList = PeopleViewModel.PeopleList;

            return PartialView("_AjaxListPeoplePartial" ,vm);
        }

        [HttpPost]
        public IActionResult DeletePerson(int id)
        {
            var personToDelete = PeopleViewModel.PeopleList.FirstOrDefault(p => p.Id == id);

            if (personToDelete != null)
            {
                PeopleViewModel.PeopleList.Remove(personToDelete);
            }

            return RedirectToAction("GetPeople");
        }

        [HttpPost]
        public IActionResult ShowPersonDetail(int id)
        {
            Person? person = PeopleViewModel.PeopleList.FirstOrDefault(p => p.Id == id);

            if (person == null)
            {
                ViewBag.ERROR = "Person not found";
            }

            return PartialView("_AjaxDetailsForPerson", person);
        }
    }
}