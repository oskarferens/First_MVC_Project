using First_MVC_App.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace First_MVC_App.ViewModels
{
    public class CountryViewModel
    {
        public static List<Country> CountryList = new List<Country>();
        public List<Country> TempList = new List<Country>();

        [Display(Name = "Country Name")]
        [Required]
        public string CountryName { get; set; }
    }
}
