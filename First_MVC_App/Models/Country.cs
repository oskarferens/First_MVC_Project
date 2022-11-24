using Microsoft.EntityFrameworkCore;

namespace First_MVC_App.Models
{
    public class Country
    {

        public int Id { get; set; }
        public string CountryName { get; set; }
        public string Capital { get; set; }
    }
}
