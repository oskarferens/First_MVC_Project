using First_MVC_App.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace First_MVC_App.ViewModels
{
    public class CityViewModel
    {
        public List<City> Cities = new List<City>();

        public int? CountryId { get; set; }
        [Display(Name = "City")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Country")]
        public Country? Country { get; set; }

        
    }
}
