using First_MVC_App.Models;

namespace First_MVC_App.ViewModels
{
    public class PeopleViewModel
    {
        public static List<Person> PeopleList { get; set; } = new List<Person>();
        public List<Person> tempList { get; set; } = new List<Person>();
        public string Search { get; set; }
        public bool CaseSensitive { get; set; }

        public CreatePersonViewModel cpvm { get; set; } = new CreatePersonViewModel();   

        public static void SeedPeople ()
        {
            PeopleList.Add(new Person(1, "John Smith", "123", 1));
            PeopleList.Add(new Person(2, "Mark Timber", "321", 2));
            PeopleList.Add(new Person(3, "Greg Kelly", "213", 3));
        }
    }
}
