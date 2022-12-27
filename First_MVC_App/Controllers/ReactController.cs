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


        //[HttpPost("create")]
        //public IActionResult Create(JsonObject person)
        //{
        //    string jsonPerson = person.ToString();
        //    Person personToCreate = JsonConvert.DeserializeObject<Person>(jsonPerson);

        //    if (personToCreate != null)
        //    {
        //        _context.PeopleList.Add(personToCreate);
        //        _context.SaveChanges();

        //        return StatusCode(200);
        //    }
        //    return StatusCode(404);
        //}


        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    var person = _context.PeopleList.Find(id);
        //    if (person != null)
        //    {
        //        _context.PeopleList.Remove(person);
        //        _context.SaveChanges();

        //        return StatusCode(200);
        //    }
        //    return StatusCode(404);
        //}
    }
}
