using First_MVC_App.Models;
using System.ComponentModel.DataAnnotations;

namespace First_MVC_App.ViewModels
{
    public class CreatePersonViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(13)]
        [MinLength(9)]
        public string PhoneNumber { get; set; }

        public int CityId { get; set; }
    }
}