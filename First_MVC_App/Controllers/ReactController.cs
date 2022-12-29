using First_MVC_App.Data;
using First_MVC_App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Nodes;

namespace First_MVC_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactController : ControllerBase
    {
        readonly ApplicationDbContext _context;
        public ReactController(ApplicationDbContext context) {
            _context = context;
        }

        [HttpGet]
        public List<Person> GetPeople() 
        {
            List<Person> people = new List<Person>();
            people = _context.PeopleList.ToList();
            return people;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var person = _context.PeopleList.Find(id);

            if (person != null)
            {
                _context.PeopleList.Remove(person);
                _context.SaveChanges();

                return StatusCode(200);
            }
            return StatusCode(404);
        }

        [HttpPost("create")]
        public IActionResult Create(JsonObject personJson)
        {
            string jsonPerson = personJson.ToString();

            PersonReact personToCreate = JsonConvert.DeserializeObject<PersonReact>(jsonPerson);

            if (personToCreate != null)
            {
                _context.PeopleList.Add(new Person { Name = personToCreate.Name, PhoneNumber = personToCreate.PhoneNumber, CityId = personToCreate.City });
                _context.SaveChanges();

                return StatusCode(200);
            }
            return StatusCode(404);
        }

        [HttpGet("countries")]
        public List<Country> GetCountry()
        {
            List<Country> country = new List<Country>();
            country = _context.CountryList.ToList();
            return country;
        }

        [HttpGet("cities")]
        public List<City> GetCity()
        {
            List<City> city = new List<City>();
            city = _context.CityList.ToList();
            return city;
        }

        [HttpGet("languages")]
        public List<Language> GetLanguage()
        {
            List<Language> language = new List<Language>();
            language = _context.LanguageList.ToList();
            return language;
        }

    }
}
