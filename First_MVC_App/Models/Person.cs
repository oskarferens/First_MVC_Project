using MessagePack;
using System.Reflection;

namespace First_MVC_App.Models
{
    public class Person
    {
        
        public string Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int CityId { get; set; }
        public int LanguageId { get; set; }
        public string City { get; set; }
        public City city { get; set; }
        public List<Language> LanguageList { get; set; } = new();

        public Person()
        {

        }
        public Person(string id, string name, string phoneNumber, string cityName)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            City = cityName;
        }
    }
}
