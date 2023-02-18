using First_MVC_App.Models;
using System.ComponentModel.DataAnnotations;

namespace First_MVC_App.ViewModels
{
    public class CountryViewModel
    {
        public List<Country> countries = new List<Country>();

        [Required]
        public string CountryName { get; set; }
        public int CountryId { get; set; }
    }
}