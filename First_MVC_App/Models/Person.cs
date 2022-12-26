 using System.ComponentModel.DataAnnotations.Schema;

namespace First_MVC_App.Models
{
    public class Person
    {
        public Person()
        {

        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int CityId { get; set; }
        public int LanguageId { get; set; }
        public City City { get; set; }
        public List<Language> LanguageList { get; set; } = new();

        public Person(int id, string name, string phoneNumber, int cityId)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            CityId = cityId;
        }
    }
}
