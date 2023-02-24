using First_MVC_App.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace First_MVC_App.ViewModels
{
    public class PeopleViewModel
    {
        public static List<Person> PeopleList { get; set; } = new List<Person>();
        public List<Person> tempList { get; set; } = new List<Person>();
        public string Search { get; set; }
        public bool CaseSensitive { get; set; }
        public int? CityId { get; set; }
        public string CityName { get; set; }
        public List<Language>? Languages { get; set; }
        public List<int>? LanguageIds { get; set; }
        public List<SelectListItem> cities { get; set; }

        public string Person { get; set; }

        [Display(Name = "Full Name")]
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "City of Residence")]
        [Required]
        public string City { get; set; }

        [Display(Name = "Language")]
        [Required]
        public string Language { get; set; }
        public static void SeedPeople()
        {
            PeopleList.Add(new Person(1, "Olof Olofsson", "0733456028", "Göteborg"));
            PeopleList.Add(new Person(2, "Per Persson", "0722456128", "Stockholm"));
            PeopleList.Add(new Person(3, "Anders Andersson", "0736426028", "Malmö"));
            PeopleList.Add(new Person(4, "Rolf Rolfsson", "0733456843", "Borås"));
            PeopleList.Add(new Person(5, "Björn Björnsson", "0733444028", "Göteborg"));
            PeopleList.Add(new Person(6, "Olof Olofsson", "0733456028", "Göteborg"));
        }
    }
}
