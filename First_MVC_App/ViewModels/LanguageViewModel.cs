using First_MVC_App.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace First_MVC_App.ViewModels
{
    public class LanguageViewModel
    {
        public List<Language> Languages { get; set; } = new();

        [Required(ErrorMessage = "Must enter any Language")]
        [Display(Name = "Enter Language")]
        public string? Name { get; set; }
    }
}
