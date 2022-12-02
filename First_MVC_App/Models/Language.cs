using System.ComponentModel.DataAnnotations;

namespace First_MVC_App.Models
{
    public class Language
    {
        [Key]
        public int LanguageId { get; set; }
        public string? Name { get; set; }

        public List<Person> PeopleList { get; set; }
    }
}
