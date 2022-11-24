using Microsoft.EntityFrameworkCore;

namespace First_MVC_App.Models
{
    public class City
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
    }
}
