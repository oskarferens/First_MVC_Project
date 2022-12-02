using First_MVC_App.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace First_MVC_App.ViewModels
{
    public class CreatePersonViewModel
    {
        [Display(Name = "Full Name")]
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "City of Residence")]
        [Required]
        public string City { get; set; }
    }
}
