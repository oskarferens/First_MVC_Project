using First_MVC_App.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace First_MVC_App.ViewModels
{
    public class LanguageViewModel
    {
        public static List<Language> LanguageList { get; set; } = new();

        public List<Language> tempList { get; set; } = new List<Language>();

        [Required(ErrorMessage = "Must enter any Language")]
        [Display(Name = "Enter Language")]
        public string? Name { get; set; }
    }
}
