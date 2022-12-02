using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace First_MVC_App.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }
        public Country? Country { get; set; }
        public List<Person> PersonList { get; set; } = new();
    }
}
