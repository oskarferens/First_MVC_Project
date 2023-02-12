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
            PeopleList.Add(new Person(4, "Roman", "435678432", 3));
            PeopleList.Add(new Person(5, "Mike", "345634567", 2));
            PeopleList.Add(new Person(6, "Kevin", "234562356", 2));
            PeopleList.Add(new Person(7, "Mikael", "24568821", 1));
            PeopleList.Add(new Person(8, "Niklas", "7845625", 1));
            PeopleList.Add(new Person(9, "Oskar", "123451345", 1));
        }
    }
}