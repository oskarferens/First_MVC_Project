using System.ComponentModel.DataAnnotations;

namespace First_MVC_App.Models
{
    public class Language
    {
        public int LanguageId { get; set; }
        public string? Name { get; set; }
        public List<Person> PeopleList { get; set; } = new();
    }
}
