using System.ComponentModel.DataAnnotations;

namespace First_MVC_App.Models
{
    public class Language
    {
        [Key]
        public int LanguageId { get; set; }

        public string LanguageName { get; set; }

        public List<Person> People { get; set; } = new List<Person>();
    }
}