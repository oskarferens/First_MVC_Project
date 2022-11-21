using MessagePack;
using System.Reflection;

namespace First_MVC_App.Models
{
    public class Person
    {
        public Person()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        

        public Person(int id, string name, string phoneNumber, string city)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            City = city;
        }
    }
}
