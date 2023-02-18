using System.ComponentModel.DataAnnotations;

namespace First_MVC_App.ViewModels
{
    public class LanguageViewModel
    {
        [Required]
        public string LanguageName { get; set; }

        public int LanguageId { get; set; }

        public int PersonId { get; set; }
    }
}