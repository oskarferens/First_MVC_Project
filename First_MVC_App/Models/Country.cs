using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace First_MVC_App.Models
{
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CountryName { get; set; }
        public List<City> Cities { get; set; } = new();
    }
}
