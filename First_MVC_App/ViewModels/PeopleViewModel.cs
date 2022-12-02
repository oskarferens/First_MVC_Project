using First_MVC_App.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace First_MVC_App.ViewModels
{
    public class PeopleViewModel
    {
        public static List<Person> PeopleList { get; set; } = new List<Person>();
        public List<Person> tempList { get; set; } = new List<Person>();
        public string Search { get; set; }
        public bool CaseSensitive { get; set; }

        public CreatePersonViewModel cpvm { get; set; } = new CreatePersonViewModel();

        public int? CityId { get; set; }

        [Display(Name = "Languages")]
        [Required]
        public List<Language>? Languages { get; set; }
        public List<int>? LanguageIds { get; set; }
        public List<SelectListItem> cities { get; set; }


    }
}
