namespace First_MVC_App.Models
{
    public class PersonDetails
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string CityName { get; set; }

        public PersonDetails(string name, string phoneNumber, string cityName)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            CityName = cityName;
        }
    }
}
