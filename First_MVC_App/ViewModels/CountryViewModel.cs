using First_MVC_App.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace First_MVC_App.ViewModels
{
    public class CountryViewModel
    {
        public List<Country> Countries = new List<Country>();

        [Display(Name = "Country")]
        [Required]
        public string Name { get; set; }
    }
}
