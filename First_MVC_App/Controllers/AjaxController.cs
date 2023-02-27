using First_MVC_App.Models;
using First_MVC_App.ViewModels;
using Microsoft.AspNetCore.Mvc;

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

            return PartialView("_AjaxListPeoplePartial", vm);
        }

        [HttpPost]
        public IActionResult DeletePerson(string id)
        {
            var personToDelete = PeopleViewModel.PeopleList.FirstOrDefault(p => p.Id == id);

            if (personToDelete != null)
            {
                PeopleViewModel.PeopleList.Remove(personToDelete);
            }

            return Json(id + " was deleted, status: " + StatusCode(200).StatusCode);
        }

        [HttpPost]
        public IActionResult ShowPersonDetail(string id)
        {
            Person person = PeopleViewModel.PeopleList.FirstOrDefault(p => p.Id == id);

            if (person == null)
            {
                ViewBag.ERROR = "Person not found";
            }

            return PartialView("_AjaxDetailsForPerson", person);
        }
    }
}