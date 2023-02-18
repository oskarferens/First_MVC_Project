using First_MVC_App.Models;
using System.ComponentModel.DataAnnotations;

namespace First_MVC_App.ViewModels
{
    public class CityViewModel
    {
        public List<City> countries = new List<City>();

        public int CountryId { get; set; }

        [Required]
        public string Name { get; set; }

        public int CityId { get; set; }
    }
}