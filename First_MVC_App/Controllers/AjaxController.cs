using First_MVC_App.Models;
using First_MVC_App.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace First_MVC_App.Controllers
{
    public class AjaxController : Controller
    {
        public static PeopleViewModel pvm = new PeopleViewModel();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetPeople()
        {
            if (PeopleViewModel.PeopleList.Count == 0)
            {
                PeopleViewModel.SeedPeople();
            }

            pvm.tempList = PeopleViewModel.PeopleList;
            return PartialView("_AjaxPersonListPartial", pvm);
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
        public IActionResult GetInfo(int id)
        {
            var personDetails = PeopleViewModel.PeopleList.FirstOrDefault(p => p.Id == id);

            if (personDetails == null)
            {
                ViewBag.ERROR = "Person not found";
            }

            return PartialView("_AjaxPersonDetails", pvm);
        }
    }
}