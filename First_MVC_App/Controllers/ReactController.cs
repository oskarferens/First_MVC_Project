﻿using First_MVC_App.Data;
using First_MVC_App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json.Nodes;

namespace First_MVC_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactController : ControllerBase
    {

        readonly ApplicationDbContext _context;

        public ReactController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Person> GetPeople()
        {
            return _context.People.Include(x => x.City).Include(y => y.City.Country).ToList(); ;
        }

        [HttpGet("cities/{id}")]
        public List<City> GetCities(int id)
        {
            return _context.Cities.Where(x => x.CountryId == id).ToList();
        }

        [HttpGet("countries")]
        public List<Country> GetCountries()
        {
            return _context.Countries.Include(y => y.Cities).ToList();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Person person = _context.People.Find(id);
            if (person == null) return StatusCode(404);

            _context.People.Remove(person);
            _context.SaveChanges();
            return StatusCode(200);
        }

        [HttpPost("create")]
        public IActionResult Create(JsonObject personJson)
        {
            string jsonPerson = personJson.ToString();

            PersonReact personToCreate = JsonConvert.DeserializeObject<PersonReact>(jsonPerson);

            if (personToCreate != null)
            {
                _context.People.Add(new Person { Name = personToCreate.Name, PhoneNumber = personToCreate.PhoneNumber, CityId = personToCreate.City });
                _context.SaveChanges();

                return StatusCode(200);
            }
            return StatusCode(404);


        }
    }
}