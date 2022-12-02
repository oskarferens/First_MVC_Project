using First_MVC_App.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace First_MVC_App.ViewModels
{
    public class CityViewModel
    {
        public static List<Person> PeopleList { get; set; } = new List<Person>();

        public static List<City> CityList = new List<City>();

        public int? CountryId { get; set; }

        [Display(Name = "Country")]
        public Country? Country { get; set; }

        [Display(Name = "City Name")]
        [Required]
        public string CityName { get; set; }
    }
}
