using System.ComponentModel.DataAnnotations;

namespace First_MVC_App.ViewModels
{
    public class PersonViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(13)]
        [MinLength(9)]
        public string PhoneNumber { get; set; }

        public int CityId { get; set; }
        public int PersonId { get; set; }
    }
}